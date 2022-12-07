using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelTwo : MonoBehaviour
{
    [SerializeField] private Sprite _targetSprite;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private TMP_Text _currentCountText;
    [SerializeField] private Board _board;

    private int _targetsCount = 12;
    private int _currentCount = 0;

    public static LevelTwo Instance { get; private set; }

    public Sprite TargetSprite => _targetSprite;
    public int TargetCount => _targetsCount;
    public int CurrentCount => _currentCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _endScreen.SetActive(false);
    }

    private void Update()
    {
        _currentCountText.text = $"Poped: {_currentCount}";

        FinishLevel();
    }

    private void OnEnable()
    {
        _board.Poped += CalculateTarget;
    }

    private void OnDisable()
    {
        _board.Poped -= CalculateTarget;
    }

    private void CalculateTarget(Sprite target)
    {
        if (target == _targetSprite)
            _currentCount++;
    }

    private void FinishLevel()
    {
        if (_currentCount == _targetsCount)
        {
            _endScreen.SetActive(true);
        }
    }
}
