using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionControlNeighbours : MonoBehaviour
{
	[SerializeField]
	GameObject leftNeighbour;
	[SerializeField]
	GameObject rightNeighbour;

	public Sprite SectionStart;
	public Sprite SectionLeftCorner;
	public Sprite SectionRightCorner;
	public Sprite SectionSingle;

	private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    	if(spriteRenderer.sprite == SectionStart && !leftNeighbour.activeSelf)
    	{
    		spriteRenderer.sprite = SectionLeftCorner;
    	}
    	else if(spriteRenderer.sprite == SectionStart && !rightNeighbour.activeSelf)
    	{
    		spriteRenderer.sprite = SectionRightCorner;
    	}
    	else if((spriteRenderer.sprite == SectionLeftCorner && !rightNeighbour.activeSelf)
    		|| (spriteRenderer.sprite == SectionRightCorner && !leftNeighbour.activeSelf))
    	{
    		spriteRenderer.sprite = SectionSingle;
    	}
    }
}