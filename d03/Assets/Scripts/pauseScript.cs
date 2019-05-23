using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour {
    private gameManager gameManager;
    public GameObject pauseCanvas;
    public GameObject confirmCanvas;
    public GameObject barCanvas;

    public void Resume() {
        pauseCanvas.SetActive(false);
        gameManager.pause(false);
        barCanvas.SetActive(true);
    }

    public void AskConfirm() {
        confirmCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }

    public void ReffuseConfirm() {
        confirmCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void AcceptConfirm() {
        SceneManager.LoadScene("ex00");
    }

	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseCanvas.activeSelf)
        {
            pauseCanvas.SetActive(true);
            gameManager.pause(true);
            barCanvas.SetActive(false);
        }
	}
}
