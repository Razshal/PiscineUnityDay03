using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerMenuScript : MonoBehaviour {
    private RaycastHit2D hit;
    private Vector3 point;
    public GameObject radialMenu;
    private GameObject instantiatedRadialMenu;

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (instantiatedRadialMenu)
                Destroy(instantiatedRadialMenu);
            
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(point, Vector2.zero);

            if (hit && hit.transform.gameObject.tag == "tower")
            {
                instantiatedRadialMenu = Instantiate(radialMenu, new Vector3(hit.transform.position.x,
                                                                             hit.transform.position.y, 50),
                                                                             hit.transform.rotation);
                instantiatedRadialMenu.transform.SetParent(hit.transform);
                instantiatedRadialMenu.GetComponent<radialMenuScript>().actualTower = hit.transform.gameObject;
            }
        }
	}
}
