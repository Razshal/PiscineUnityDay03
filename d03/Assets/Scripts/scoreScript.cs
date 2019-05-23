using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {
    public Text endText;
    public Text score;
    public Text grade;
    public Button reload;
    public Button nextLevel;
    private gameManager gameManager;
    private char gradeLetter;
    private int scoreValue;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager")
                                .GetComponent<gameManager>();
        
        scoreValue = gameManager.playerEnergy + gameManager.playerHp;
        if (scoreValue == 320)
            gradeLetter = 'A';
        else if (scoreValue < 320 && scoreValue >= 300)
            gradeLetter = 'B';
        else if (scoreValue < 300 && scoreValue >= 280)
            gradeLetter = 'C';
        else if (scoreValue < 280 && scoreValue >= 200)
            gradeLetter = 'D';
        else if (scoreValue < 200 && scoreValue >= 100)
            gradeLetter = 'E';
        else if (scoreValue < 100)
            gradeLetter = 'F';
        score.text = "" + scoreValue;
        grade.text = "" + gradeLetter;

        if (gameManager.playerHp <= 0)
        {
			nextLevel.gameObject.SetActive(false);
            endText.text = "Game Over";
        }
        else
        {
			reload.gameObject.SetActive(false);
            endText.text = "You win !";
        }
    }
}
