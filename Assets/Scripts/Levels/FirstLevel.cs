using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private TMP_Text _targetScoreText;
    [SerializeField] private ScoreCounter _currentScore;
    [SerializeField] private int _targetScore;

    private void Start()
    {
        _targetScoreText.text = $"Target: {_targetScore}";
        _endScreen.SetActive(false);
    }

    private void Update()
    {
        CompleteLevel();
    }

    private void CompleteLevel()
    {
        if (_currentScore.Score >= _targetScore)
        {
            if (Board.Instance.IsWorking == false)
            { 
                _endScreen.SetActive(true);
                _gameScreen.SetActive(false);
            }
        }
    }
}
