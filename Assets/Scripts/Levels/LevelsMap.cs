using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMap : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private Button _secondLevelButton;
    [SerializeField] private Button _thirdLevelButton;
    [SerializeField] private Button _fourthLevelButton;

    private int _levelComplete;

    private void Start()
    {
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");

        for (int buttonIterator = 0; buttonIterator < _levelButtons.Length; buttonIterator++)
        {
            _levelButtons[buttonIterator].interactable = false;
        }

        switch (_levelComplete)
        {
            case 1:
                ChangeButtonInteractable(_levelComplete);
                break;
            case 2:
                ChangeButtonInteractable(_levelComplete);
                break;
            case 3:
                ChangeButtonInteractable(_levelComplete);
                break;
            case 4:
                ChangeButtonInteractable(_levelComplete);
                break;            
            case 5:
                ChangeButtonInteractable(_levelComplete);
                break;            
            case 6:
                ChangeButtonInteractable(_levelComplete);
                break;
            case 7:
                ChangeButtonInteractable(_levelComplete);
                break;
            case 8:
                ChangeButtonInteractable(_levelComplete);
                break;
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        for (int buttonIterator = 0; buttonIterator < _levelButtons.Length; buttonIterator++)
        {
            _levelButtons[buttonIterator].interactable = false;
        }

        PlayerPrefs.DeleteKey("LevelComplete");
    }

    public void LoadHardcoreLevelsMap()
    {
        SceneManager.LoadScene("HardcoreLevelsMap");
    }

    private void ChangeButtonInteractable(int buttonCount)
    {
        for(int buttonIterator = 0; buttonIterator < buttonCount; buttonIterator++)
        {
            _levelButtons[buttonIterator].interactable = true;
        }
    }
}
