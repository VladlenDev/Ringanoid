using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SaveData
{
  	public int SavedCountUnlockedLevel;
  	public int SavedChosenBG;
  	public int SavedChosenBall;
  	public int SavedChosenRing;
  	public int[] SavedLevelScore = new int[LevelManagement.countLevels];
}

public class saveSerialData : MonoBehaviour
{
	static bool dataIsLoaded = false;

	void Start()
	{
		if(!dataIsLoaded)
		{
			LoadGame();
			dataIsLoaded = true;
		}
	}

	public static void SaveGame()
	{
  		BinaryFormatter bf = new BinaryFormatter(); 
  		FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat"); 
  		SaveData data = new SaveData();
  		data.SavedCountUnlockedLevel = LevelManagement.countUnlockedLevel;
  		data.SavedChosenBG = ItemsManagement.ChosenBackground;
  		data.SavedChosenBall = ItemsManagement.ChosenBall;
  		data.SavedChosenRing = ItemsManagement.ChosenRing;
  		for(int i = 0; i < LevelManagement.countLevels; i++)
  		{  			
  			data.SavedLevelScore[i] = LevelManagement.levelScore[i];
  		}
  		bf.Serialize(file, data);
  		file.Close();
	}

	public static void LoadGame()
	{
	  	if (File.Exists(Application.persistentDataPath 
    	+ "/SaveData.dat"))
  		{
    		BinaryFormatter bf = new BinaryFormatter();
    		FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
    		SaveData data = (SaveData)bf.Deserialize(file);
    		file.Close();
    		LevelManagement.countUnlockedLevel = data.SavedCountUnlockedLevel;
    		ItemsManagement.ChosenBackground = data.SavedChosenBG;
    		ItemsManagement.ChosenBall = data.SavedChosenBall;
    		ItemsManagement.ChosenRing = data.SavedChosenRing;
  			for(int i = 0; i < LevelManagement.countLevels; i++)
  			{  			
  				LevelManagement.levelScore[i] = data.SavedLevelScore[i];
  			}
  		}
	}
}
