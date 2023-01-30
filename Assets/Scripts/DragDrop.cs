using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas _canvas;

    private RectTransform _rectTransform;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = eventData.pointerDrag.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.position = _startPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherTileTransform = eventData.pointerDrag.transform;

        _rectTransform.position = otherTileTransform.position;
        otherTileTransform.position = _startPosition;
    }
}
