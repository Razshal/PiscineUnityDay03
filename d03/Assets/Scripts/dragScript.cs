using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject tower;
    private towerScript towerScript;
    private Vector3 originPos;
    private Ray ray;
	private RaycastHit2D hit;
    private GameObject tile;
    private Vector3 point;
    private gameManager gameManager;
    public Text towerDesc;

	void Start()
	{
        gameManager = GameObject.Find("GameManager")
                                .GetComponent<gameManager>();
        towerScript = tower.GetComponent<towerScript>();

        // Tower stats
        towerDesc.text = towerScript.damage + "\n" 
            + towerScript.range + "\n" 
            + towerScript.energy;
	}

    private bool EnoughEnergy()
    {
        return gameManager.playerEnergy >= towerScript.energy;
    }

	public void OnBeginDrag(PointerEventData eventData)
    {
        originPos = gameObject.transform.position;
    }

	public void OnDrag(PointerEventData eventData)
    {
        if (EnoughEnergy())
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(point.x, point.y, 12);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		gameObject.transform.position = originPos;

        hit = Physics2D.Raycast(point, Vector2.zero);

        if (Physics2D.Raycast(point, Vector2.zero)) {
            tile = hit.transform.gameObject;
            if (tile.tag == "empty")
            {
                Instantiate(tower, tile.transform.position, tile.transform.rotation);
                Destroy(hit.transform.gameObject);
                gameManager.playerEnergy -= towerScript.energy;
            }
        }
    }

	void Update()
	{
        if (!EnoughEnergy())
            gameObject.GetComponent<Image>().color = Color.red;
        else
            gameObject.GetComponent<Image>().color = Color.white;
	}
}
