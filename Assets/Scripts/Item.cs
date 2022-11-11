using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Match-3/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private int _value;
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
    public int Value => _value;
}
