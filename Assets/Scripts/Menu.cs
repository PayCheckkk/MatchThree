using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startScreen;
    [SerializeField] private CanvasGroup _gameScreen;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _startScreen.alpha = 0;
        _startScreen.blocksRaycasts = false;
        _gameScreen.alpha = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("LevelsMap");
    }
}
