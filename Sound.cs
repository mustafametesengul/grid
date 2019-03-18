using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

	void Awake()
	{
		AudioListener.volume = 6;
	}

	public Sprite sound;
	public Sprite soundG;

	public void SoundOnOff()
	{
		GameObject.Find("GameSounds").GetComponents<AudioSource>()[2].Play();

		if(gameObject.GetComponent<Settings>().sound)
		{
			gameObject.GetComponent<Settings>().sound = false;
			GameObject.Find("Sound").GetComponent<Image>().sprite = sound;
		
			AudioListener.volume = 0;
		}
		else
		{
			gameObject.GetComponent<Settings>().sound = true;
			GameObject.Find("Sound").GetComponent<Image>().sprite = soundG;
		
			AudioListener.volume = 6;
		}
		
	}
}
