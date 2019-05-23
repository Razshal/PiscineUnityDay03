using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject dragged;
    private Vector3 originPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragged = gameObject;
        originPos = gameObject.transform.position;
    }

	public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragged = null;
        gameObject.transform.position = originPos;
    }
}
