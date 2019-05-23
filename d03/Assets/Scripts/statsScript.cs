using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsScript : MonoBehaviour {
	public Text energy;
    public Text life;
    private gameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager")
                        .GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        life.text = gameManager.playerHp + "/" + gameManager.playerMaxHp;
        energy.text = "" + gameManager.playerEnergy;
	}
}
