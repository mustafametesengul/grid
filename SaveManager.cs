using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {


	public void Save()
	{
		PlayerPrefs.SetInt("lastLevel", GameObject.Find("GameEngine").GetComponent<LevelSelection>().lastLevel);
		PlayerPrefs.Save();
	}


}
