using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinUnlocker : MonoBehaviour
{
	public GameObject GridBGs;
	public GameObject GridBalls;
	public GameObject GridRings;

	private int unlockedBGs;
	private int unlockedBalls;
	private int unlockedRings;

    void Update()
    {
        unlockedBGs = (LevelManagement.countUnlockedLevel + 1) / 3;
        unlockedBalls = LevelManagement.countUnlockedLevel / 3;
        unlockedRings = (LevelManagement.countUnlockedLevel - 1) / 3;

        SetUnlockedItems(GridBGs, unlockedBGs);
        SetUnlockedItems(GridBalls, unlockedBalls);
        SetUnlockedItems(GridRings, unlockedRings);
    }

    void SetUnlockedItems(GameObject Grid, int countUnlockedItem)
    {
    	for (int i = 0; i < Grid.transform.childCount; i++)
        {
            if (i <= countUnlockedItem)
            {
                Grid.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                Grid.transform.GetChild(i).gameObject.SetActive(false);
            }
        }	
    }
}
