using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardcoreLevelOne : Levels
{
    [SerializeField] private Image _firstTargetIcon;
    [SerializeField] private Image _secondTargetIcon;

    private Sprite _firstTarget;
    private Sprite _secondTarget;
    private int _levelsCompleted;

    private void Start()
    {
        Time.timeScale = 1;

        _endScreen.SetActive(false);
        _loseLevelScreen.SetActive(false);

        GanerateNewTargets();

        FixTargetText();

        _swapCountText.SetText($"Pop count: {_swapCount}");
    }

    private void Update()
    {
        _currentPopCountText.text = $"Poped: {_currentPopCount}  /  {_secondCurrentPopCount}";

        _swapCountText.SetText($"Swap count: {_swapCount} / {_maxSwapCount}");

        CompleteLevel();

        FixTargetText();

        FinishLevel();
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
        if (target == _firstTarget)
            _currentPopCount++;

        if (target == _secondTarget)
            _secondCurrentPopCount++;
    }

    private void ChooseTarget(ref Sprite target)
    {
        int random = Random.Range(0, _targetsSprites.Length);

        target = _targetsSprites[random];
    }

    private void ChangeSprite(Image icon, Sprite sprite)
    {
        icon.sprite = sprite;
    }

    private void GanerateNewTargets()
    {
        ChooseTarget(ref _firstTarget);
        ChooseTarget(ref _secondTarget);

        ChangeSprite(_firstTargetIcon, _firstTarget);
        ChangeSprite(_secondTargetIcon, _secondTarget);
    }

    private void FixTargetText()
    {
        _targetText.text = $"Target: {_targetPopCount} x";
        _secondTargetText.text = $"Target: {_secondTargetPopCount} x";
    }

    protected override void CompleteLevel()
    {
        if (_currentPopCount >= _targetPopCount && _secondCurrentPopCount >= _secondTargetPopCount)
        {
            _currentPopCount = 0;
            _secondCurrentPopCount = 0;
            _targetPopCount++;
            _secondTargetPopCount++;
            _levelsCompleted++;
            GanerateNewTargets();
        }
    }

    private void CalculateSwap()
    {
        _swapCount++;
    }

    private void FinishLevel()
    {
        if (_swapCount >= _maxSwapCount)
        {
            _gameScreen.SetActive(false);
            _endScreen.SetActive(true);
        }
    }
}
