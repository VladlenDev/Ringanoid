using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainCustomizer : MonoBehaviour
{
	public GameObject Background;
	public GameObject ButtonRing;	
	public GameObject ButtonBG;
	public GameObject ButtonBall;

	public Sprite[] Rings;
	public Sprite[] Backgrounds;
	public Sprite[] BgIcons;
	public Sprite[] Balls;

    void Update()
    {
        Background.GetComponent<Image>().sprite = Backgrounds[ItemsManagement.ChosenBackground];
        ButtonRing.transform.GetChild(0).GetComponent<Image>().sprite = Rings[ItemsManagement.ChosenRing];
        ButtonBG.transform.GetChild(0).GetComponent<Image>().sprite = BgIcons[ItemsManagement.ChosenBackground];
        ButtonBall.transform.GetChild(0).GetComponent<Image>().sprite = Balls[ItemsManagement.ChosenBall];
    }
}
