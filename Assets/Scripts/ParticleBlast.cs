using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleBlast : MonoBehaviour
{
    [SerializeField] private ParticleSystem _octahedronBlast;
    [SerializeField] private ParticleSystem _cubeBlast;
    [SerializeField] private ParticleSystem _sphereBlast;
    [SerializeField] private ParticleSystem _cylinderBlast;
    [SerializeField] private ParticleSystem _pyramidBlast;

    [SerializeField] private Sprite _octahedron;
    [SerializeField] private Sprite _cube;
    [SerializeField] private Sprite _sphere;
    [SerializeField] private Sprite _cylinder;
    [SerializeField] private Sprite _pyramid;

    private float _timerForDestroy = 0;

    public static ParticleBlast Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _timerForDestroy += Time.deltaTime;

        if (_timerForDestroy >= 10)
        {
            DestroyBlast();
            _timerForDestroy = 0;
        }
    }

    public void Blast(Tile tile)
    {
        var tileTransform = tile.GetComponent<Transform>();

        if (tile.Icon.sprite == _octahedron)
        {
            InstantiateBlast(_octahedronBlast, tileTransform);
        }

        else if (tile.Icon.sprite == _cube)
        {
            InstantiateBlast(_cubeBlast, tileTransform);
        }

        else if (tile.Icon.sprite == _sphere)
        {
            InstantiateBlast(_sphereBlast, tileTransform);
        }

        else if (tile.Icon.sprite == _cylinder)
        {
            InstantiateBlast(_cylinderBlast, tileTransform);
        }

        else if (tile.Icon.sprite == _pyramid)
        {
            InstantiateBlast(_pyramidBlast, tileTransform);
        }
    }

    private void InstantiateBlast(ParticleSystem blast, Transform tileTransform)
    {
        Instantiate(blast, tileTransform.position, Quaternion.identity);

        blast.Play();
    }

    private void DestroyBlast()
    {
        GameObject[] blasts;

        blasts = GameObject.FindGameObjectsWithTag("Blow");

        for (int blastIterator = 0; blastIterator < blasts.Length; blastIterator++)
        {
            Destroy(blasts[blastIterator].gameObject);
        }
    }
}
