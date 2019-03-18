using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using admob;

public class WinControler : MonoBehaviour {


	public LevelSelection levelSelection;
	public GridControler gridControler;
	public SwipeControler swipeControler;
	public BallMovemant ballMovemant;
	int winInt = 0;
	public GameObject lightAnim;
	public int winCounter = 0;
	
	List<List<int>> winPositions = new List<List<int>>();

	void Start () 
	{
		Admob.Instance().initAdmob("ca-app-pub-5188168190344391/6789555357","ca-app-pub-5188168190344391/8011960468");
		Admob.Instance().loadInterstitial();

		Invoke("SetWinPosition", 1);
	}

	void CheckWinCondition()
	{

		for(int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				if(gridControler.grid[i,j] == -1)
				{
					foreach(var position in winPositions)
					{
						if(i == position[0] && j == position[1])
						{
							winInt += 1;
						}
					}
				}
			}
		}


		if(winInt == winPositions.Count && winPositions.Count != 0)
		{

			DisableControles();
			CreateLights();
			Invoke("DestroyLights", 1.5f);
			
			Invoke("LevelUp", 1.5f);

			SetTextNumber();
			SendMessage("SetOpenableLevelUp");
			SendMessage("SetOpenableRefresh");

			Invoke("LevelUpAnimation", 0.5f);
			GameObject.Find("GameSounds").GetComponents<AudioSource>()[5].Play();

			if(levelSelection.currentLevel == gameObject.GetComponent<LevelSelection>().lastLevel)
			{
				gameObject.GetComponent<LevelSelection>().lastLevel += 1;
			}
			
			winCounter += 1;

			GameObject.Find("GameEngine").GetComponent<SaveManager>().Save();

			if(winCounter % 5 == 0)
			{
				//Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
				
				if(Admob.Instance().isInterstitialReady())
				{
					Admob.Instance().showInterstitial();
				}
				Admob.Instance().loadInterstitial();

			}

		}
	
		winInt = 0;
	}

	void SetWinPosition()
	{
		
		EnableControles();

		winPositions.Clear();

		for(int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				if(gridControler.grid[i,j] == 1 || gridControler.grid[i,j] == -2)
				{
					winPositions.Add(new List<int> {i, j});
				}
			}
		}

	}

	void CreateLights()
	{
		for(int i = 0; i < 5; i++)
		{
			for(int j = 0; j < 5; j++)
			{
				if(gridControler.grid[i,j] == -1)
				{
					Instantiate(lightAnim, new Vector3(-i+2f,j-2f,0)*-1.14f, new Quaternion(0,0,0,0));
				}
			}
		}
	}

	void DestroyLights()
	{
		var lights = GameObject.FindGameObjectsWithTag ("Light");
     
			for(var i = 0 ; i < lights.Length ; i++)
			{
				Destroy(lights[i]);
			}
	}

	void LevelUp()
	{
		levelSelection.currentLevel += 1;
		gridControler.SetGridLevel();
	}

	void DisableControles()
	{
		swipeControler.enabled = false;
		ballMovemant.enabled = false;
	}

	void EnableControles()
	{
		swipeControler.enabled = true;
		ballMovemant.enabled = true;
	}

	void LevelUpAnimation()
	{
		GameObject.Find("MenuTab").GetComponent<Animator>().Play("menuLevelUp");
		GameObject.Find("TextLevelUp").GetComponent<Animator>().Play("textLevelUp");
		GameObject.Find("TextLevelUpNumber").GetComponent<Animator>().Play("textLevelUpNumber");

		GameObject.Find("GameSounds").GetComponents<AudioSource>()[3].Play();
	}

	void SetTextNumber()
	{
		GameObject.Find("TextLevelUpNumber").GetComponent<Text>().text = (levelSelection.currentLevel + 1).ToString();
	}
}
