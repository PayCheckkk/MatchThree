using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private Row[] _rows;
    [SerializeField] private CanvasGroup _endScreen;

    private const float TweenDuration = 0.2f;

    private const int SelectionsToTriggerSwap = 2;

    private const int MatchesToTriggerPop = 2;

    public int Width => _width;

    public int Height => _height;

    public Tile[,] Tiles { get; private set; }

    private int _width => Tiles.GetLength(0);

    private int _height => Tiles.GetLength(1);

    private readonly List<Tile> _selection = new List<Tile>();

    public static Board Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _endScreen.alpha = 0;
        Tiles = new Tile[_rows.Max(row => row.Tiles.Length), _rows.Length];

        for (var rowIterator = 0; rowIterator < _height; rowIterator++)
        {
            for (var tileIterator = 0; tileIterator < _width; tileIterator++)
            {
                var tile = _rows[rowIterator].Tiles[tileIterator];

                tile.SetX(tileIterator);
                tile.SetY(rowIterator);

                tile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];

                Tiles[tileIterator, rowIterator] = tile;
            }
        }

        while (CanPop())
            Pop(false);
    }

    public async void Select(Tile tile)
    {
        if (_selection.Contains(tile) == false)
            _selection.Add(tile);

        if (_selection.Count < SelectionsToTriggerSwap)
            return;

        var random = new System.Random();

        var firstSelectionTileX = _selection[0].X;
        var firstSelectionTileY = _selection[0].Y;
        var secondSelectionTileX = _selection[1].X;
        var secondSelectionTileY = _selection[1].Y;
        var selectionsTilesDifferenceX = firstSelectionTileX - secondSelectionTileX;
        var selectionsTilesDifferenceY = firstSelectionTileY - secondSelectionTileY;

        if (Mathf.Abs(selectionsTilesDifferenceX) + Mathf.Abs(selectionsTilesDifferenceY) > 1)
        {
            await Swap(_selection[0], _selection[1]);
            await Swap(_selection[0], _selection[1]);
            _selection.Clear();
            return;
        }

        await Swap(_selection[0], _selection[1]);

        if (CanPop())
        {
            Pop(true);
        }
        else
        {
            await Swap(_selection[0], _selection[1]);
        }

        _selection.Clear();
    }

    public async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.Icon;
        var icon2 = tile2.Icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();

        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.SetIcon(icon2);
        tile2.SetIcon(icon1);

        var tile1Item = tile1.Item;

        tile1.Item = tile2.Item;
        tile2.Item = tile1Item;
    }

    private bool CanPop()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= MatchesToTriggerPop)
                    return true;
            }
        }

        return false;
    }

    private async void Pop(bool animate = true)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = Tiles[x, y];

                var connectedTiles = tile.GetConnectedTiles();

                if (connectedTiles.Skip(1).Count() < MatchesToTriggerPop)
                    continue;

                if (animate == true)
                {
                    var deflateSequence = DOTween.Sequence();

                    foreach (var connectedTile in connectedTiles)
                        deflateSequence.Join(connectedTile.Icon.transform.DOScale(Vector3.zero, TweenDuration));

                    await deflateSequence.Play().AsyncWaitForCompletion();

                    ScoreCounter.Instance.Score += tile.Item.Value * connectedTiles.Count;
                }

                var inflateSequence = DOTween.Sequence();

                foreach (var connectedTile in connectedTiles)
                {
                    connectedTile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];

                    if (animate == true)
                        inflateSequence.Join(connectedTile.Icon.transform.DOScale(Vector3.one, TweenDuration));
                }

                if (animate == true)
                    await inflateSequence.Play().AsyncWaitForCompletion();

                x = 0;
                y = 0;

                if (ScoreCounter.Instance.Score >= Target.Instance.TargetScore)
                {
                    _endScreen.alpha = 1;
                }
            }
        }
    }
}
