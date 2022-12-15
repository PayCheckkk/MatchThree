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
        EndScreen.SetActive(false);
    }

    private void Update()
    {
        CurrentCountText.text = $"Poped: {_currentCount}";

        CompleteLevel();
    }

    private void OnEnable()
    {
        Board.Poped += CalculateTarget;
    }

    private void OnDisable()
    {
        Board.Poped -= CalculateTarget;
    }

    private void CalculateTarget(Sprite target)
    {
        if (target == TargetSprite)
            _currentCount++;
    }

    private void CompleteLevel()
    {
        if (_currentCount == TargetCount)
        {
            FinishLevel();
        }
    }

    protected override void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("LevelComplete", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("LevelsMap");
    }
}
