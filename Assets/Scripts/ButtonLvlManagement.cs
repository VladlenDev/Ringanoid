using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//	this script loads scene from scene manager number of input integer.
public class ButtonLvlManagement : MonoBehaviour {

	public void LoadLevelScene(int numLvl)
    {
        SceneManager.LoadScene(numLvl);
    }
}