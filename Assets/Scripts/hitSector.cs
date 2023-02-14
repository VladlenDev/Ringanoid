using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  theese are sides of screen, from one of them the ball comes.
public enum ScreenSide
{
	LEFT,
	RIGHT,
	TOP,
	BOTTOM
}

//  this script describes the ball's actions.
public class hitSector : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rigitbody;

	public float gameHeight;
	public float gameWidth;
	public float ballResistance;
    public AudioClip SectionSound;
    public AudioClip DiamondSound;

	private SpriteRenderer ballSprite;
    private CircleCollider2D coll;
	private float sidePos;
	private ScreenSide GameSide;
    private AudioSource audioSource;
    
    void Start()
    {
		SetNewPosition();
		coll = gameObject.GetComponent<CircleCollider2D>();
		ballSprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.3f;
    }

    void Update()
    {
    	if(IsOutOfScreen())
    	{
    		SetNewPosition();
	    	coll.enabled = true;
    	}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Section") || 
            col.gameObject.CompareTag("Corner") ||
            col.gameObject.CompareTag("CornerL") ||
            col.gameObject.CompareTag("CornerR"))
        {
            audioSource.PlayOneShot(SectionSound);
        	coll.enabled = false;
        	rigitbody.gravityScale = 1f;
			StartDeath();
        }

        else if(col.gameObject.CompareTag("Diamond"))
        {
            audioSource.PlayOneShot(DiamondSound);
            coll.enabled = false;
            rigitbody.gravityScale = 1f;
            StartDeath();
        }
    }

    void SetNewPosition()
    {
    	rigitbody.gravityScale = 0f;
		GameSide = (ScreenSide)Random.Range(0, 3);

		switch(GameSide)
		{
			case ScreenSide.LEFT:
			sidePos = Random.Range(-gameHeight, gameHeight);
			gameObject.transform.position = new Vector3(-gameWidth, sidePos, 0f);
			break;
			case ScreenSide.RIGHT:
			sidePos = Random.Range(-gameHeight, gameHeight);
			gameObject.transform.position = new Vector3(gameWidth, sidePos, 0f);
			break;
			case ScreenSide.TOP:
			sidePos = Random.Range(-gameWidth, gameWidth);
			gameObject.transform.position = new Vector3(sidePos, gameHeight, 0f);
			break;
			case ScreenSide.BOTTOM:
			sidePos = Random.Range(-gameWidth, gameWidth);
			gameObject.transform.position = new Vector3(sidePos, -gameHeight, 0f);
			break;
		}

		rigitbody.velocity = new Vector2(
			-gameObject.transform.position.x/ballResistance, 
			-gameObject.transform.position.y/ballResistance);
    }

    bool IsOutOfScreen()
    {
    	return (gameObject.transform.position.x > gameWidth
    		|| gameObject.transform.position.y > gameHeight
    		|| -gameObject.transform.position.x > gameWidth
    		|| -gameObject.transform.position.y > gameHeight);
    }

    IEnumerator Invisible()
    {
    	for(float f = 1f; f >= 0f; f -= 0.05f)
    	{
    		Color color = ballSprite.material.color;
    		color.a = f;
    		ballSprite.material.color = color;
    		yield return new WaitForSeconds(0.01f);
    	}
        SetNewPosition();
		Color reColor = ballSprite.material.color;
    	reColor.a = 1f;
    	ballSprite.material.color = reColor;
        coll.enabled = true;
    }

    public void StartDeath()
    {
    	StartCoroutine("Invisible");
    }
}
