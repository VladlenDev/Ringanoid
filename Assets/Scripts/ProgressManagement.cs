using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManagement : MonoBehaviour
{
	public int currentLevel;
	public int ChildPlayerID;
	public int ChildCoreID;
	public GameObject LevelUI;

	private int RingCount = 0;
	private GameObject PlayerRing;
	private GameObject Core;

	void Start()
	{
		PlayerRing = transform.GetChild(ChildPlayerID).gameObject;
		Core = transform.GetChild(ChildCoreID).gameObject;

		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).gameObject.CompareTag("Ring") ||
                transform.GetChild(i).gameObject.CompareTag("Square") ||
                transform.GetChild(i).gameObject.CompareTag("Triangle"))
			{
				RingCount++;
			}
		}
	}

    void Update()
    {
        #region CheckWin
        if (!IsPlayerActive())
        {
            if (currentLevel == LevelManagement.countUnlockedLevel)
            {
                LevelManagement.countUnlockedLevel++;
            }

            if(Core.GetComponent<coreHealth>().GetHealth() >= LevelManagement.levelScore[currentLevel-1])
            {
                LevelManagement.levelScore[currentLevel-1] = Core.GetComponent<coreHealth>().GetHealth();
            }

            saveSerialData.SaveGame();
            LevelUI.GetComponent<winMenu>().ShowWinMenu();
        }
        #endregion

        #region CheckLose
        if (!Core.activeSelf)
        {
            LevelUI.GetComponent<looseMenu>().ShowLooseMenu();
        }
        #endregion
    }

	bool IsPlayerActive()
    {
    	for(int currentRing = 0; currentRing < RingCount; currentRing++)
    	{
    		PlayerRing = transform.GetChild(ChildPlayerID + currentRing).gameObject;
        	for(int i = 0; i < PlayerRing.transform.childCount; i++)
    		{
    			for(int j = 0; j < PlayerRing.transform.GetChild(i).transform.childCount; j++)
    			{
    				if(PlayerRing.transform.GetChild(i).transform.GetChild(j).gameObject.activeSelf)
    				{
    					PlayerRing = transform.GetChild(ChildPlayerID).gameObject;
    					return true;
    				}
    			}
    		}
    	}
    	PlayerRing = transform.GetChild(ChildPlayerID).gameObject;
    	return false;
    }
}
