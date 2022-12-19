using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Levels : MonoBehaviour
{
    [SerializeField] protected Sprite _targetSprite;
    [SerializeField] protected GameObject _endScreen;
    [SerializeField] protected TMP_Text _currentCountText;
    [SerializeField] protected Board _board;
    [SerializeField] protected int _targetCount;

    public int TargetCount => _targetCount;
}
