using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Levels : MonoBehaviour
{
    [SerializeField] protected GameObject _endScreen;
    [SerializeField] protected GameObject _gameScreen;
    [SerializeField] protected GameObject _loseLevelScreen;

    [SerializeField] protected Sprite _targetSprite;
    [SerializeField] protected Sprite[] _targetsSprites;
    [SerializeField] protected Sprite _secondTargetSprite;

    [SerializeField] protected TMP_Text _currentPopCountText;
    [SerializeField] protected TMP_Text _targetText;
    [SerializeField] protected TMP_Text _secondTargetText;
    [SerializeField] protected TMP_Text _swapCountText;

    [SerializeField] protected Board _board;

    [SerializeField] protected int _targetPopCount;
    [SerializeField] protected int _secondTargetPopCount;
    [SerializeField] protected int _maxSwapCount;

    protected int _currentPopCount = 0;
    protected int _secondCurrentPopCount = 0;
    protected int _swapCount = 0;

    protected abstract void CompleteLevel();
}
