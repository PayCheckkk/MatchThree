using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasResolution : MonoBehaviour
{
    [SerializeField] private RectTransform _boardTransform;

    private float _aspect = (float)Screen.width / (float)Screen.height;

    private void Start()
    {
        _boardTransform.GetComponent<RectTransform>();

        if (_aspect >= 1.87)
        {
            _boardTransform.transform.localPosition = new Vector3(46, 0, 0);
            Debug.Log("19.5:9");
        }

        else if (_aspect >= 1.74)
        {
            _boardTransform.transform.localPosition = new Vector3(153, 0, 0);
            Debug.Log("16:9");
        }

        else if (_aspect >= 1.6)
        {
            _boardTransform.transform.localPosition = new Vector3(196, 0, 0);
            Debug.Log("5:3");
        }

        else if (_aspect >= 1.5)
        {
            _boardTransform.transform.localPosition = new Vector3(196, 0, 0);
            Debug.Log("3:2");
        }

        else if (_aspect >= 1.33)
        {
            _boardTransform.transform.localPosition = new Vector3(217, -47, 0);
            Debug.Log("4:3");
        }

        else if(_aspect >= 0.5)
        {
            _boardTransform.transform.localPosition = new Vector3(0, -67, 0);
            Debug.Log("9:16");
        }

        else if(_aspect >= 0.4)
        {
            _boardTransform.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log("9:21");
        }
    }
}
