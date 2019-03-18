using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Sprite menu;
	public Sprite menuG;
	public GameObject menuButton;
	public SwipeControler swipeControler;
	public GameObject buttonNormal;
	public GameObject buttonLocked;
	int levelLength = 20;
	public int lastLevel;
	Text text;
	public bool openState = false;
	public bool openable = true;

	IEnumerator CreateButtons()
	{
		lastLevel = GameObject.Find("GameEngine").GetComponent<LevelSelection>().lastLevel;

		yield return new WaitForSeconds(0.2f);
		for(int i = 0; i < lastLevel; i++)
		{
			
			var button = GameObject.Instantiate(buttonNormal, Vector3.zero, Quaternion.Euler(new Vector3(0, 0, Random.Range(-0.5f,0.5f))));
			button.transform.SetParent(GameObject.Find("Content").transform, false);
			text = button.GetComponentInChildren<Text>();
			text.text = ((int.Parse(text.text) + i).ToString());
			yield return new WaitForSeconds(0.002f);
		}
		
		for(int i = 0; i < levelLength-lastLevel; i++)
		{
			
			var button = GameObject.Instantiate(buttonLocked, Vector3.zero, Quaternion.Euler(new Vector3(0, 0, Random.Range(-0.5f,0.5f))));
			button.transform.SetParent(GameObject.Find("Content").transform, false);
			text = button.GetComponentInChildren<Text>();
			text.text = ((lastLevel + i + 1).ToString());
			yield return new WaitForSeconds(0.0021f);
		}


	}


	IEnumerator DestroyButtons()
	{
		GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		foreach(var button in buttons)
		{
			button.GetComponent<Animator>().Play("buttonPopout");
			yield return new WaitForSeconds(0.002f);
		}

		yield return new WaitForSeconds(0.1f);

		foreach(var button in buttons)
		{
			Destroy(button);
		}
	}

	public void OpenCloseMenu()
	{
		GameObject.Find("GameSounds").GetComponents<AudioSource>()[2].Play();

		if(openable)
		{	

			openable = false;

			if(openState == false)
			{
				PlaySwoop();

				StartCoroutine(CreateButtons());
				
				GameObject menuOpen = GameObject.Find("MenuTab");
				menuOpen.GetComponent<Animator>().Play("menuOpen");
				
				swipeControler.enabled = false;
				gameObject.GetComponent<Refresh>().openable=false;
				openState = true;

				menuButton = GameObject.Find("Menu");
				menuButton.GetComponent<Image>().sprite = menuG;
			}
			else if(openState == true)
			{
				Invoke("PlaySwoop", 0.1f);

				StartCoroutine(DestroyButtons());

				GameObject menuOpen = GameObject.Find("MenuTab");
				menuOpen.GetComponent<Animator>().Play("menuClose");
			
				swipeControler.enabled = true;
				Invoke("SetRefreshOpenableTrue", 1f);
				openState = false;

				menuButton = GameObject.Find("Menu");
				menuButton.GetComponent<Image>().sprite = menu;
			}
			StartCoroutine(SetOpenable());
		}
		
		
		
		
	}

	IEnumerator SetOpenable()
	{
		yield return new WaitForSeconds(1f);
		openable = true;
	}

	IEnumerator SetOpenableLevelUp()
	{
		openable = false;
		yield return new WaitForSeconds(2.5f);
		openable = true;
	}

	void SetRefreshOpenableTrue()
	{
		gameObject.GetComponent<Refresh>().openable=true;
	}


	void PlaySwoop()
	{
		GameObject.Find("GameSounds").GetComponents<AudioSource>()[4].Play();
	}
}
