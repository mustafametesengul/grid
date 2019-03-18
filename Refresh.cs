using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refresh : MonoBehaviour {

	public bool openable;

	public void RefreshGrid()
	{
		GameObject.Find("GameSounds").GetComponents<AudioSource>()[2].Play();

		if(openable)
		{
			GameObject.Find("GameSounds").GetComponents<AudioSource>()[3].Play();

			openable = false;

			SendMessage("SetOpenableLevelUp");

			Invoke("RefreshCurrentLevel", 1f);

			GameObject.Find("TextLevelUpNumber").GetComponent<Text>().text = (gameObject.GetComponent<LevelSelection>().currentLevel).ToString();
			GameObject.Find("MenuTab").GetComponent<Animator>().Play("menuLevelUp");
			GameObject.Find("TextLevelUp").GetComponent<Animator>().Play("textLevelUp");
			GameObject.Find("TextLevelUpNumber").GetComponent<Animator>().Play("textLevelUpNumber");
		
			StartCoroutine(SetOpenableRefresh());
		}
		
	}

	void RefreshCurrentLevel()
	{
		SendMessage("SetGridLevel");
	}

	IEnumerator SetOpenableRefresh()
	{
		openable = false;
		yield return new WaitForSeconds(2.5f);
		openable = true;
	}

}
