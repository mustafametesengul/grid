using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {

	public int currentLevel = 1;
	public int lastLevel = 1;

	// Use this for initialization
	void Start () 
	{


		if(PlayerPrefs.HasKey("lastLevel"))
		{

			if(PlayerPrefs.GetInt("lastLevel") == 0 || PlayerPrefs.GetInt("lastLevel") == 1)
			{
				currentLevel = 1;
				lastLevel = 1;
			}
			else
			{
				currentLevel = PlayerPrefs.GetInt("lastLevel");
				lastLevel = PlayerPrefs.GetInt("lastLevel");
			
			}

		}
		
		else
		{
			currentLevel = 1;
			lastLevel = 1;
		}
		
	}

	
}
