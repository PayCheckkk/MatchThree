using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _endLevelScreen;
    [SerializeField] private Button _nextLevelButton;

    private void Start()
    {
        _endLevelScreen.alpha = 1;
        _endLevelScreen.blocksRaycasts = true;
    }

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("LevelComplete", SceneManager.GetActiveScene().buildIndex);
    }
}
