using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour {

	GameObject gameEngine;


	public void SetButtonLevel()
	{
		gameEngine = GameObject.Find("GameEngine");
		gameEngine.GetComponent<LevelSelection>().currentLevel = int.Parse(gameObject.GetComponentInChildren<Text>().text);
		
		gameEngine.GetComponent<GridControler>().SetGridLevel();

		gameEngine.GetComponent<Menu>().OpenCloseMenu();
		
	}
}
