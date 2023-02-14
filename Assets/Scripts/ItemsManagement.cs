using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManagement : MonoBehaviour
{
	public static int ChosenRing = 0;
	public static int ChosenBackground = 0;
	public static int ChosenBall = 0;

	public void ChooseRing(int RingNum)
	{
		ChosenRing = RingNum;
		saveSerialData.SaveGame();
	}
	public void ChooseBackground(int BgNum)
	{
		ChosenBackground = BgNum;
		saveSerialData.SaveGame();
	}
	public void ChooseBall(int BallNum)
	{
		ChosenBall = BallNum;
		saveSerialData.SaveGame();
	}
}
