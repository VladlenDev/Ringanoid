using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class looseMenu : MonoBehaviour
{
	public GameObject LooseMenuUI;

    public void ShowLooseMenu()
    {
    	LooseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
        pauseMenu.LevelIsOver = true;
    }

    public void Retry()
    {
    	Time.timeScale = 1f;
	   	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
     	Time.timeScale = 1f;
	   	SceneManager.LoadScene("GameScene");
    }
}
