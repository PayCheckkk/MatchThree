using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSix : Levels
{
    private void Start()
    {
        Time.timeScale = 1;

        _endScreen.SetActive(false);
        _loseLevelScreen.SetActive(false);

        _swapCountText.SetText($"Pop count: {_swapCount}");
        _targetText.text = $"Target: {_targetPopCount} x";
        _secondTargetText.text = $"Target: {_secondTargetPopCount} x";
    }

    private void Update()
    {
        _currentPopCountText.text = $"Poped: {_currentPopCount}  /  {_secondCurrentPopCount}";

        _swapCountText.SetText($"Swaped: {_swapCount} / {_maxSwapCount}");

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
            _currentPopCount++;
        
        if (target == _secondTargetSprite)
            _secondCurrentPopCount++;
    }

    protected override void CompleteLevel()
    {
        if (_currentPopCount >= _targetPopCount && _secondCurrentPopCount >= _secondTargetPopCount)
        {
            _gameScreen.SetActive(false);
            _endScreen.SetActive(true);
        }
    }

    private void CalculateSwap()
    {
        _swapCount++;
    }

    private void LoseLevel()
    {
        if (_swapCount >= _maxSwapCount)
        { 
            _gameScreen.SetActive(false);
            _loseLevelScreen.SetActive(true);
        }
    }
}
