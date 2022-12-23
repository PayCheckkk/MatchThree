using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardcoreLevelsMap : MonoBehaviour
{
    public void LoadTo(int levelNumber)
    {
        SceneManager.LoadScene($"HardcoreLevel {levelNumber}");
    }

    public void BackToDefaultLevels()
    {
        SceneManager.LoadScene("LevelsMap");
    }
}
