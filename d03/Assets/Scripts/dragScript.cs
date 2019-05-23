using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject tower;
    private Vector3 originPos;
	private RaycastHit hit;
    private GameObject tile;
    private Vector3 point;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originPos = gameObject.transform.position;
    }

	public void OnDrag(PointerEventData eventData)
    {
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(point.x, point.y, 12);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		gameObject.transform.position = originPos;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Debug.Log("Hit!");
            tile = hit.transform.gameObject;
            if (tile.tag == "empty")
            {
                Instantiate(tower, tile.transform.position, tile.transform.rotation);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
