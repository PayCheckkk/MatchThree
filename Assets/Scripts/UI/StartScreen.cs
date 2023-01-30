using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startScreen.SetActive(true);
        _gameScreen.SetActive(false);
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        _startScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }
}
