using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private TMP_Text _targetScoreText;
    [SerializeField] private ScoreCounter _currentScore;
    [SerializeField] private int _targetScore;

    private void Start()
    {
        _targetScoreText.text = $"Target: {_targetScore}";
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
                FinishLevel();
        }
    }

    private void FinishLevel()
    {
        SceneManager.LoadScene(1);
    }
}
