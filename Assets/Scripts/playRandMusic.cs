using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandMusic : MonoBehaviour
{
	private AudioSource audioSource;

	public AudioClip[] clips;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = 0.2f;
		audioSource.loop = false;
    }

    void Update()
    {
    	if(pauseMenu.LevelIsOver)
    	{
    		audioSource.Stop();
    	}
    	else if(!audioSource.isPlaying)
    	{
    		audioSource.clip = GetRandomClip();
    		audioSource.Play();
    	}
    }

    private AudioClip GetRandomClip()
    {
    	return clips[Random.Range(0, clips.Length)];
    }
}
