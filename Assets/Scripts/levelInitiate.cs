using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelInitiate : MonoBehaviour
{
	public GameObject[] objects;

    void Start()
    {
        for(int i = 0; i < objects.Length; i++)
        {
        	Instantiate(objects[i], objects[i].transform.position, Quaternion.identity);
        }
    }
}
