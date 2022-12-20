using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMap : MonoBehaviour
{
    [SerializeField] private Button _secondLevelButton;
    [SerializeField] private Button _thirdLevelButton;
    private int _levelComplete;

    private void Start()
    {
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");
        _secondLevelButton.interactable = false;
        _thirdLevelButton.interactable = false;

        switch (_levelComplete)
        {
            case 1:
                _secondLevelButton.interactable = true;
                break;
            case 2:
                _secondLevelButton.interactable = true;
                _thirdLevelButton.interactable = true;
                break;
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        _secondLevelButton.interactable = false;
        _thirdLevelButton.interactable = false;
        PlayerPrefs.DeleteKey("LevelComplete");
    }
}
