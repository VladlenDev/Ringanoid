using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
    public static bool LevelIsOver = false;

	public GameObject PauseMenuUI;

    void Start()
    {
        LevelIsOver = false;
    }

    void Update()
    {
        if(StartMenu.LevelIsStarted && !LevelIsOver && Input.GetKeyDown(KeyCode.Escape))
        {
        	if(GameIsPaused)
        	{
        		Resume();
        	}
        	else
        	{
        		Pause();
        	}
        }
    }

    public void Resume()
    {
    	PauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    void Pause()
    {
    	PauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    public void MainMenu()
    {
     	Time.timeScale = 1f;
	   	SceneManager.LoadScene("GameScene");
    }
}
