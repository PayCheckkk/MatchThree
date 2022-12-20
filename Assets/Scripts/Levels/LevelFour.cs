using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelFour : Levels
{
    [SerializeField] private GameObject _loseLevelScreen;

    [SerializeField] protected Sprite _secondTargetSprite;

    [SerializeField] private TMP_Text _swapCountText;
    [SerializeField] protected TMP_Text _secondCurrentPopCountText;

    [SerializeField] private int _maxSwapCount;

    private int _currentPopCount = 0;
    private int _secondCurrentPopCount = 0;
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
        _currentPopCountText.text = $"Poped: {_currentPopCount}";
        _secondCurrentPopCountText.text = $"Second poped: {_secondCurrentPopCount}";

        _swapCountText.SetText($"Swap count: {_swapCount}");

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
