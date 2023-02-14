using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour {

    public static int countLevels = 30;
    public static int countUnlockedLevel = 1;
    public static int[] levelScore = new int[countLevels];

    [SerializeField]
    Sprite unlockedIcon;

    [SerializeField]
    Sprite lockedIcon;

    void Start () {
        int numLvl = 1;
        GameObject LevelsGrid;
        Transform Score;

        for (int j = 0; j < transform.childCount; j++)
        {
            LevelsGrid = transform.GetChild(j).gameObject;

            for (int i = 0; i < LevelsGrid.transform.childCount; i++)
            {
                numLvl = j * 15 + i + 1;
                LevelsGrid.transform.GetChild(i).gameObject.name = numLvl.ToString();
                LevelsGrid.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();

                Score = LevelsGrid.transform.GetChild(i).transform.GetChild(1);
                for(int k = 0; k < Score.childCount; k++)
                {
                    if(k < levelScore[numLvl-1])
                    {
                       Score.GetChild(k).gameObject.SetActive(true);
                    }
                    else
                    {
                       Score.GetChild(k).gameObject.SetActive(false);
                    }
                }

                if ((j * 15 + i) < countUnlockedLevel)
                {
                    LevelsGrid.transform.GetChild(i).GetComponent<Image>().sprite = unlockedIcon;
                    LevelsGrid.transform.GetChild(i).GetComponent<Button>().interactable = true;
                }
                else
                {
                    LevelsGrid.transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon;
                    LevelsGrid.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
            }               
        }
	}
}