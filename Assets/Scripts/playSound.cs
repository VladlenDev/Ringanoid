using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
  	public AudioClip ButtonSound;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayButtonSound()
  	{
  		audioSource.volume = 0.3f;
    	audioSource.PlayOneShot(ButtonSound);
  	}
}
