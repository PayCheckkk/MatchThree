using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelThree : Levels
{
    [SerializeField] private TMP_Text _swapCountText;
    [SerializeField] private int _maxSwapCount;
    [SerializeField] private GameObject _loseLevelScreen;

    private int _currentCount = 0;
    private int _swapCount = 0;

    private void Start()
    {
        Time.timeScale = 1;

        _endScreen.SetActive(false);
        _loseLevelScreen.SetActive(false);

        _swapCountText.SetText($"Pop count: {_swapCount}");
    }

    private void Update()
    {
        _currentPopCountText.text = $"Poped: {_currentCount}";
        _swapCountText.SetText($"Pop count: {_swapCount}");

        CompleteLevel();
        LoseLevel();
    }

    private void OnEnable()
    {
        _board.Poped += CalculateTarget;
        _board.Swaped += CalculateSwap;
    }

    private void OnDisable()
    {
        _board.Poped -= CalculateTarget;
        _board.Swaped -= CalculateSwap;
    }

    private void CalculateTarget(Sprite target)
    {
        if (target == _targetSprite)
            _currentCount++;
    }

    protected override void CompleteLevel()
    {
        if (_currentCount == _targetPopCount)
        {
            _gameScreen.SetActive(false);
            _endScreen.SetActive(true);
        }
    }

    private void CalculateSwap()
    {
        _swapCount++;
    }

    protected override void LoseLevel()
    {
        if (_swapCount >= _maxSwapCount)
        { 
            _gameScreen.SetActive(false);
            _loseLevelScreen.SetActive(true);
        }
    }
}
