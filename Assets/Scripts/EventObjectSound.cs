using UnityEngine;
using System.Collections;

public class EventObjectSound : MonoBehaviour
{
	public AudioClip audioClip;
	private AudioSource audioSource;
	
	public void PlaySound ()
	{
		audioSource.Stop ();
		
		if (audioClip && audioSource) {
			audioSource.Play ();
		}
	}

	public void PlaySoundOneShot ()
	{
		audioSource.Stop ();
		
		if (audioClip && audioSource) {
			audioSource.PlayOneShot (audioClip);
		}
	}
	
	public void StopSound ()
	{
		audioSource.Stop ();
	}

	// Use this for initialization
	void Start ()
	{
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = audioClip;

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
