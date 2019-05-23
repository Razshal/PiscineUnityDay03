using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsScript : MonoBehaviour {
	public Text energy;
    public Text life;
    private gameManager gameManager;

	void Start () {
        gameManager = GameObject.Find("GameManager")
                                .GetComponent<gameManager>();
	}
	
	void Update () {
        life.text = gameManager.playerHp + "/" + gameManager.playerMaxHp;
        energy.text = "" + gameManager.playerEnergy;
	}
}
