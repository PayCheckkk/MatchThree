using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startScreen;
    [SerializeField] private CanvasGroup _gameScreen;
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startScreen.alpha = 1;
        _startScreen.blocksRaycasts = true;
        _gameScreen.alpha = 0;
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
        _startScreen.alpha = 0;
        _startScreen.blocksRaycasts = false;
        _gameScreen.alpha = 1;
        _startButton.interactable = false;
    }
}
