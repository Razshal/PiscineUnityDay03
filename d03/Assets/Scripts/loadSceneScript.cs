using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneScript : MonoBehaviour {
	public void LoadSceneOnClick()
	{
        SceneManager.LoadScene("ex01");
	}

    public void LoadMainMenuOnClick()
    {
        SceneManager.LoadScene("ex00");
    }

    public void QuitSceneOnClick()
    {
        Application.Quit();
    }
}
