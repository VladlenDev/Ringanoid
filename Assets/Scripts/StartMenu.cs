using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static bool LevelIsStarted = false;
	public GameObject StartMenuUI;

    void Start()
    {
    	StartMenuUI.SetActive(true);
    	Time.timeScale = 0f;
        pauseMenu.GameIsPaused = true;
        LevelIsStarted = false;
    }

    public void Play()
    {
    	StartMenuUI.SetActive(false);
    	Time.timeScale = 1f;
        pauseMenu.GameIsPaused = false;
        LevelIsStarted = true;
    }
}