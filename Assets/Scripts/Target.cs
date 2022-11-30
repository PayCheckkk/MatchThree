using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetText;

    public static Target Instance { get; private set; }

    private int _targetScore = 1000;

    public int TargetScore => _targetScore;

    private void Awake()
    {
        Instance = this;
    }
}