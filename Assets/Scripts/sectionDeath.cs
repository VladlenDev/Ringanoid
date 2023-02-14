using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sectionDeath : MonoBehaviour
{
	SpriteRenderer section;

    void Start()
    {
        section = GetComponent<SpriteRenderer>();
    }

    IEnumerator Invisible()
    {
    	for(float f = 1f; f >= 0f; f -= 0.05f)
    	{
    		Color color = section.material.color;
    		color.a = f;
    		section.material.color = color;
    		yield return new WaitForSeconds(0.01f);
    	}
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
        	StartDeath();
        }
    }

    public void StartDeath()
    {
    	StartCoroutine("Invisible");
    }
}
