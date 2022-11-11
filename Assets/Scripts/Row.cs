using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] private Tile[] _tiles;

    public Tile[] Tiles => _tiles;
}
