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
    public GameObject endGameCanvas;
    GameObject[] spawners;

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
        spawners = GameObject.FindGameObjectsWithTag("spawner");
	}

    bool checkLastEnemy()
    {
        if (gameManager.gm.lastWave == true)
        {
            foreach (GameObject spawner in spawners)
                if (spawner.GetComponent<ennemySpawner>().isEmpty == false || spawner.transform.childCount > 1)
                    return false;
            if (!GameObject.FindWithTag("bot") 
                && !GameObject.FindWithTag("flybot") 
                && !GameObject.FindWithTag("boss"))
                return true;
        }
        return false;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseCanvas.activeSelf)
        {
            pauseCanvas.SetActive(true);
            gameManager.pause(true);
            barCanvas.SetActive(false);
        }
        if (gameManager.playerHp <= 0 || checkLastEnemy())
        {
            gameManager.pause(true);
            endGameCanvas.SetActive(true);
            barCanvas.SetActive(false);
        }
	}
}
