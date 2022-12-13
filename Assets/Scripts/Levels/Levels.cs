using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Levels : MonoBehaviour
{
    [SerializeField] private Sprite _targetSprite;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private TMP_Text _currentCountText;
    [SerializeField] private Board _board;
    [SerializeField] private int _targetCount;

    public Sprite TargetSprite => _targetSprite;
    public GameObject EndScreen => _endScreen;
    public Board Board => _board;
    public TMP_Text CurrentCountText => _currentCountText;
    public int TargetCount => _targetCount;

    protected abstract void FinishLevel();
}
