using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  this script controls core's (diamond's) health;
//  in the beggining core has 3 points of health;
//  if a ball hits the core, it loses 1 point of health;
//  if core's health turns 0 points, it "dies" and becomes inactive;
//  also this script returns points of health in func below.
public class coreHealth : MonoBehaviour
{
	private int health;
	SpriteRenderer CoreSprite;

    void Start()
    {
        health = 3;
        CoreSprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
        	health--;

        	if(health == 0)
        	{
        		StartDeath();
        	}
        }
    }

    public int GetHealth()
    {
    	return health;
    }

    IEnumerator Invisible()
    {
    	for(float f = 1f; f >= 0f; f -= 0.05f)
    	{
    		Color color = CoreSprite.material.color;
    		color.a = f;
    		CoreSprite.material.color = color;
    		yield return new WaitForSeconds(0.01f);
    	}
        gameObject.SetActive(false);
    }

    public void StartDeath()
    {
    	StartCoroutine("Invisible");
    }
}