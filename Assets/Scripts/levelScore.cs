using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScore : MonoBehaviour
{
	public GameObject Core;
	private int CoreHealth;

    void Start()
    {
    	for(int i = 0; i < transform.childCount; i++)
    	{
    		transform.GetChild(i).gameObject.SetActive(true);
    	}
    }

    void Update()
    {
        CoreHealth = Core.GetComponent<coreHealth>().GetHealth();

        for(int i = 0; i < transform.childCount; i++)
    	{
    		if(i >= CoreHealth)
    		{    			
    			transform.GetChild(i).gameObject.SetActive(false);
    		}
    	}

    }
}
