using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;

    private RawImage _image;
    private float _imagePositionX;
    private float _imagePositionY;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionX += _xSpeed * Time.deltaTime;
        _imagePositionY += _ySpeed * Time.deltaTime;

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);    
    }
}
