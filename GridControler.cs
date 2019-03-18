using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControler : MonoBehaviour {

	public int[,] grid = new int[5,5];
	public LevelSelection levelSelection;
	public GameObject block1;
	public GameObject block2;
	public GameObject ball;


	void Start()
	{
		Invoke("CreateGrid", 1f);
	}

	void CreateGrid()
	{
		//Set grid
		for(int i = 0; i < 5; i++)
		{
			for(int j = 0; j<5; j++)
			{
				grid[i,j] = 0;
			}
		}


		//Write all levels here
		if(levelSelection.currentLevel == 1)
		{
			this.grid[1,0] = -1;
			this.grid[1,3] = -1;
			this.grid[4,4] = 1;
			this.grid[2,4] = 1;
			this.grid[3,1] = 2;
		}
		else if(levelSelection.currentLevel == 2)
		{
			this.grid[2,0] = 1;
			this.grid[2,1] = 1;
			this.grid[3,0] = 2;
			this.grid[4,4] = -1;
			this.grid[2,4] = -1;
			this.grid[3,1] = 2;
		}
		else if(levelSelection.currentLevel == 3)
		{
			this.grid[0,0] = 1;
			this.grid[1,0] = 1;
			this.grid[2,0] = 1;
			this.grid[2,1] = 2;
			this.grid[3,2] = 2;
			this.grid[3,0] = -1;
			this.grid[4,0] = -1;
			this.grid[2,4] = -1;
		}
		else if(levelSelection.currentLevel == 4)
		{
			this.grid[0,0] = 1;
			this.grid[0,3] = 1;
			this.grid[3,2] = 1;
			this.grid[4,1] = 2;
			this.grid[2,2] = 2;
			this.grid[4,0] = -1;
			this.grid[2,0] = -1;
			this.grid[2,4] = -1;
		}
		else if(levelSelection.currentLevel == 5)
		{
			this.grid[0,1] = 1;
			this.grid[0,3] = 1;
			this.grid[0,4] = 1;
			this.grid[2,2] = 2;
			this.grid[0,2] = 2;
			this.grid[3,0] = -1;
			this.grid[2,0] = -1;
			this.grid[3,2] = -1;
		}
		else if(levelSelection.currentLevel == 6)
		{
			this.grid[2,4] = 1;
			this.grid[3,0] = 1;
			this.grid[4,0] = -2;
			this.grid[2,1] = 2;
			this.grid[2,3] = 2;
			this.grid[2,0] = -1;
			this.grid[2,2] = -1;
		}
		else if(levelSelection.currentLevel == 7)
		{
			this.grid[0,2] = 1;
			this.grid[0,4] = 1;
			this.grid[4,3] = 1;
			this.grid[1,1] = 2;
			this.grid[3,3] = 2;
			this.grid[1,3] = 2;
			this.grid[2,0] = -1;
			this.grid[2,4] = -1;
			this.grid[2,2] = -1;
		}
		else if(levelSelection.currentLevel == 8)
		{
			this.grid[4,0] = 1;
			this.grid[4,2] = 1;
			this.grid[4,1] = 2;
			this.grid[2,3] = 2;
			this.grid[1,0] = 2;
			this.grid[2,2] = -1;
			this.grid[2,4] = -1;
		}
		else if(levelSelection.currentLevel == 9)
		{
			this.grid[0,0] = 1;
			this.grid[0,2] = 1;
			this.grid[0,4] = 1;
			this.grid[3,1] = 1;
			this.grid[2,1] = 2;
			this.grid[2,3] = 2;
			this.grid[3,3] = 2;
			this.grid[3,2] = -1;
			this.grid[2,0] = -1;
			this.grid[2,2] = -1;
			this.grid[1,0] = -1;
		}
		else if(levelSelection.currentLevel == 10)
		{
			this.grid[0,4] = 1;
			this.grid[4,0] = 1;
			this.grid[2,4] = 1;
			this.grid[3,4] = 1;

			this.grid[1,1] = 2;
			this.grid[4,3] = 2;
			this.grid[4,1] = 2;
			this.grid[4,2] = -1;
			this.grid[1,0] = -1;
			this.grid[1,2] = -1;
			this.grid[3,0] = -1;
		}
		else if(levelSelection.currentLevel == 11)
		{
			this.grid[0,0] = 1;
			this.grid[1,1] = 1;
			this.grid[0,4] = 1;
			this.grid[1,4] = 1;

			this.grid[0,1] = 2;
			this.grid[0,3] = 2;
			this.grid[4,2] = 2;
			this.grid[2,2] = -1;
			this.grid[2,0] = -1;
			this.grid[1,2] = -1;
			this.grid[3,0] = -1;
		}
		else if(levelSelection.currentLevel == 12)
		{
			this.grid[3,0] = 1;
			this.grid[4,0] = -2;
			this.grid[1,1] = 1;
			this.grid[4,4] = 1;

			this.grid[2,1] = 2;
			this.grid[0,3] = 2;
			this.grid[3,1] = 2;
			this.grid[4,2] = -1;
			this.grid[1,0] = -1;
			this.grid[1,2] = -1;
		}
		else if(levelSelection.currentLevel == 13)
		{
			this.grid[1,0] = 1;
			this.grid[2,2] = 1;
			this.grid[4,0] = 1;

			this.grid[0,2] = 2;
			this.grid[2,1] = 2;
			this.grid[3,3] = 2;
			this.grid[0,4] = 2;
			this.grid[3,2] = -1;
			this.grid[2,0] = -1;
			this.grid[1,2] = -1;
		}
		else if(levelSelection.currentLevel == 14)
		{
			this.grid[0,0] = 1;
			this.grid[4,0] = 1;
			this.grid[2,3] = -2;

			this.grid[3,2] = 2;
			this.grid[2,2] = 2;
			this.grid[1,3] = 2;

			this.grid[2,4] = -1;
			//this.grid[2,3] = -1;
			this.grid[1,1] = -1;
		}
		else if(levelSelection.currentLevel == 15)
		{
			this.grid[4,0] = 1;
			this.grid[4,1] = 1;
			this.grid[2,4] = 1;
			this.grid[3,4] = 1;

			this.grid[4,4] = 2;
			this.grid[0,2] = 2;
			this.grid[2,2] = 2;
			this.grid[4,2] = 2;

			this.grid[2,1] = -1;
			this.grid[2,3] = -1;
			this.grid[3,3] = -1;
			this.grid[1,0] = -1;
		}
		else if(levelSelection.currentLevel == 16)
		{
			this.grid[0,4] = 1;
			this.grid[1,2] = 1;
			this.grid[4,1] = 1;
			this.grid[4,3] = 1;

			this.grid[1,4] = 2;
			this.grid[0,2] = 2;
			this.grid[2,2] = 2;
			this.grid[3,2] = 2;

			this.grid[3,1] = -1;
			this.grid[1,3] = -1;
			this.grid[3,3] = -1;
			this.grid[1,0] = -1;
		}
		else if(levelSelection.currentLevel == 17)
		{
			this.grid[0,1] = -2;
			this.grid[2,2] = 1;
			this.grid[4,0] = 1;
			this.grid[4,3] = 1;

			this.grid[0,0] = 2;
			this.grid[4,4] = 2;
			this.grid[1,1] = 2;
			this.grid[3,2] = 2;
			this.grid[2,4] = 2;

			//this.grid[0,1] = -1;
			this.grid[0,2] = -1;
			this.grid[3,3] = -1;
			this.grid[1,3] = -1;
		}
		else if(levelSelection.currentLevel == 18)
		{
			this.grid[0,4] = 1;
			this.grid[1,4] = 1;
			this.grid[3,4] = -2;
			this.grid[4,4] = 1;

			this.grid[1,1] = 2;
			this.grid[3,3] = 2;
			this.grid[2,1] = 2;
			this.grid[2,4] = 2;

			this.grid[4,0] = -1;
			this.grid[1,0] = -1;
			this.grid[1,2] = -1;
			//this.grid[3,4] = -1;
		}
		else if(levelSelection.currentLevel == 19)
		{
			this.grid[1,4] = -2;
			this.grid[3,4] = 1;
			this.grid[4,1] = 1;
			this.grid[4,3] = -2;

			this.grid[1,1] = 2;
			this.grid[2,2] = 2;
			this.grid[4,4] = 2;
			this.grid[2,4] = 2;

			//this.grid[4,3] = -1;
			this.grid[1,0] = -1;
			this.grid[1,3] = -1;
			//this.grid[1,4] = -1;
		}
		else if(levelSelection.currentLevel == 20)
		{
			this.grid[0,1] = 1;
			this.grid[0,2] = 1;
			this.grid[0,4] = 1;
			this.grid[1,4] = 1;
			this.grid[2,4] = 1;

			this.grid[2,2] = 2;
			this.grid[0,3] = 2;
			this.grid[4,3] = 2;
			this.grid[2,3] = 2;
			this.grid[0,0] = 2;

			this.grid[3,1] = -1;
			this.grid[4,4] = -1;
			this.grid[1,3] = -1;
			this.grid[1,0] = -1;
			this.grid[3,4] = -1;
		}


		//Spawn blocks
		for(int i = 0; i < 5; i++)
		{
			for(int j = 0; j<5; j++)
			{
				if(grid[i,j] == -1)
				{
					Instantiate(ball, new Vector3(-i+2f,j-2f,0)*-1f, new Quaternion(0,0,0,0));
				}

				else if(grid[i,j] == 1)
				{
					Instantiate(block1, new Vector3(-i+2f,j-2f,0)*-1f, new Quaternion(0,0,0,0));
				}

				else if(grid[i,j] == 2)
				{
					Instantiate(block2, new Vector3(-i+2f,j-2f,0)*-1f, new Quaternion(0,0,0,0));
				}
				else if(grid[i,j] == -2)
				{
					Instantiate(block1, new Vector3(-i+2f,j-2f,0)*-1f, new Quaternion(0,0,0,0));
					Instantiate(ball, new Vector3(-i+2f,j-2f,0)*-1f, new Quaternion(0,0,0,0));
				}
			}
		}

	}

	void DestroyGrid()
	{
		var gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		
		for (int i = 0; i < gameObjects.Length; i++)
		{
			if(gameObjects[i].name.Contains("block"))
			{
				Destroy(gameObjects[i]);
			}
		}

		for (int i = 0; i < gameObjects.Length; i++)
		{
			if(gameObjects[i].name.Contains("ball"))
			{
				Destroy(gameObjects[i]);
			}
		}

	}

	public void SetGridLevel()
	{
		DestroyGrid();
		CreateGrid();
		SendMessage("SetWinPosition");
	}

}
