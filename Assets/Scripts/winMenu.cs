using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winMenu : MonoBehaviour
{
	public GameObject WinMenuUI;
    public GameObject CoreHealth;

    private GameObject ScoreGrid;

    void Start()
    {
        ScoreGrid = WinMenuUI.transform.GetChild(WinMenuUI.transform.childCount-1).gameObject;
    }

    public void ShowWinMenu()
    {
    	WinMenuUI.SetActive(true);
        CoreHealth.SetActive(false);
    	Time.timeScale = 0f;
        pauseMenu.LevelIsOver = true;

        for(int i = 0; i < ScoreGrid.transform.childCount; i++)
        {
            if(CoreHealth.transform.GetChild(i).gameObject.activeSelf)
            {
                ScoreGrid.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {                
                ScoreGrid.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
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

    public void NextLevel()
    {
    	Time.timeScale = 1f;
	   	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}