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
    private int bestScore;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager")
                                .GetComponent<gameManager>();
        
        scoreValue = gameManager.playerEnergy / 100 + gameManager.playerHp * 10;
        bestScore = gameManager.playerStartEnergy / 100 + gameManager.playerMaxHp * 10;
        if (scoreValue >= bestScore)
            gradeLetter = 'A';
        else if (scoreValue < bestScore && scoreValue >= bestScore / 2)
            gradeLetter = 'B';
        else if (scoreValue < bestScore / 2 && scoreValue >= bestScore / 3)
            gradeLetter = 'C';
        else if (scoreValue < bestScore / 3 && scoreValue >= bestScore / 4)
            gradeLetter = 'D';
        else if (scoreValue < bestScore / 4 && scoreValue >= bestScore / 5)
            gradeLetter = 'E';
        else if (scoreValue < bestScore / 5)
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
