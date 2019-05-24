using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radialMenuScript : MonoBehaviour {
    public Button upgradeButton;
    public Button downgradeButton;
    public Text upgradeCost;
    public Text downgradeCost;
    public GameObject actualTower;
    public GameObject empty;
    public GameObject radialPanel;
    private towerScript towerScript;
    private int upgrade;
    private int downgrade;

	// Use this for initialization
	void Start () 
    {
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        towerScript = actualTower.GetComponent<towerScript>();

        radialPanel.transform.position = actualTower.transform.position;

        upgrade = towerScript.upgrade ?
                             towerScript.upgrade.GetComponent<towerScript>().energy 
                             : 0;
        downgrade = towerScript.energy / 2;
        towerScript = actualTower.GetComponent<towerScript>();
        if (towerScript.upgrade)
        {
			upgradeCost.text = "" + upgrade;
            upgradeButton.onClick.AddListener(OnUpgradeClick);
        }
        else
        {
            upgradeCost.text = "";
            upgradeButton.gameObject.SetActive(false);
        }
        downgradeCost.text = "" + downgrade;
        downgradeButton.onClick.AddListener(OnDowngradeClick);
	}

    void OnUpgradeClick() 
    {
        if (gameManager.gm.playerEnergy >= upgrade)
        {
            gameManager.gm.playerEnergy -= upgrade;
            Instantiate(towerScript.upgrade,
                                    actualTower.transform.position,
                                    actualTower.transform.rotation);
            Destroy(actualTower);
            Destroy(gameObject);
        }
    }

    void OnDowngradeClick() 
    {
        gameManager.gm.playerEnergy += downgrade;
        if (towerScript.downgrade)
        {
            Instantiate(towerScript.downgrade,
                                    actualTower.transform.position,
                                    actualTower.transform.rotation);
        }
        else
        {
            Instantiate(empty,
                        actualTower.transform.position,
                        actualTower.transform.rotation);
        }
        Destroy(actualTower);
        Destroy(gameObject);
    }
}
