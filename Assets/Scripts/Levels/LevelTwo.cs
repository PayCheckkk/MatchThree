using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : Levels
{
    private void Start()
    {
        Time.timeScale = 1;
        _endScreen.SetActive(false);
    }

    private void Update()
    {
        _currentPopCountText.text = $"Poped: {_currentPopCount}";

        CompleteLevel();
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
            _currentPopCount++;
    }

    protected override void CompleteLevel()
    {
        if (_currentPopCount == _targetPopCount)
        {
            _endScreen.SetActive(true);
            _gameScreen.SetActive(false);
        }
    }
}
