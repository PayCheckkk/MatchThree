using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Levels : MonoBehaviour
{
    [SerializeField] protected Sprite _targetSprite;
    [SerializeField] protected GameObject _endScreen;
    [SerializeField] protected GameObject _gameScreen;
    [SerializeField] protected TMP_Text _currentPopCountText;
    [SerializeField] protected Board _board;
    [SerializeField] protected int _targetPopCount;

    public int TargetCount => _targetPopCount;

    protected abstract void CompleteLevel();
}
