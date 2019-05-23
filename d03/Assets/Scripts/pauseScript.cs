using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour {
    private gameManager gameManager;
    public GameObject pauseCanvas;

    public void Resume() {
        pauseCanvas.SetActive(false);
        gameManager.pause(false);
    }

	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseCanvas.activeSelf)
        {
            pauseCanvas.SetActive(true);
            gameManager.pause(true);
        }
	}
}
