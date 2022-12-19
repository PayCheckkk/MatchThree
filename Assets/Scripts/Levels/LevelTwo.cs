using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : Levels
{
    private int _currentCount = 0;

    private void Start()
    {
        Time.timeScale = 1;
        _endScreen.SetActive(false);
    }

    private void Update()
    {
        _currentCountText.text = $"Poped: {_currentCount}";

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
            _currentCount++;
    }

    private void CompleteLevel()
    {
        if (_currentCount == _targetCount)
        {
            _endScreen.SetActive(true);
        }
    }
}
