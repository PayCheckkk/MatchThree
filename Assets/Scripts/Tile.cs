using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;

    private int _x;
    private int _y;

    private Item _item;

    public int X => _x;
    public int Y => _y;

    public Image Icon => _icon;

    public Item Item
    {
        get => _item;
        
        set
        {
            if (_item == value) 
                return;

            _item = value;

            _icon.sprite = _item.Sprite;
        }
    }

    public void SetX(int number)
    {
        _x = number;
    }

    public void SetY(int number)
    {
        _y = number;
    }

    public void SetIcon(Image icon)
    {
        _icon = icon;
    }

    public Tile Left => _x > 0 ? Board.Instance.Tiles[_x - 1, _y] : null;
    public Tile Top => _y > 0 ? Board.Instance.Tiles[_x, _y - 1] : null;
    public Tile Right => _x < Board.Instance.Width - 1 ? Board.Instance.Tiles[_x + 1, _y] : null;
    public Tile Bottom => _y < Board.Instance.Height - 1 ? Board.Instance.Tiles[_x, _y + 1] : null;

    public Tile[] Neighbours => new[]
    {
        Left,
        Top,
        Right,
        Bottom
    };

    private void Start()
    {
        _button.onClick.AddListener(() => Board.Instance.Select(this));
    }

    public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
    {
        var result = new List<Tile> { this, };

        if(exclude == null)
        {
            exclude = new List<Tile> { this };
        }
        else
        {
            exclude.Add(this);
        }

        foreach (var neighbour in Neighbours)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item)
                continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }
}
