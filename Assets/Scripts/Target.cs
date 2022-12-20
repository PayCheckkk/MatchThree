using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TMP_Text _targetText;
    [SerializeField] private Levels _level;

    public static Target Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _targetText.text = $"Targets: {_level.TargetPopCount} x      / {_level.SecondTargetPopCount} x";
    }
}
