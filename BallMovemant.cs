using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
using System.Linq;

public class BallMovemant : MonoBehaviour {

	private int timer = 12;
	private int counter = 0;
	List<GameObject> ballsToMove = new List<GameObject>();
	List<Vector3> ballDestinations = new List<Vector3>();
	List<Vector3> ballStartPositions = new List<Vector3>();
	public SwipeControler swipeControler;
	public GridControler gridControler;
	public WinControler winControler;
	public bool playSwipeSound = false;
	List<GameObject> balls;

	void Update () 
	{		

		if(counter > 0)
		{
			counter -= 1;
		}

		else if(counter == 0)
		{

			if(swipeControler.swipeLeft)
			{
				balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));

				balls = balls.OrderBy(ballPosition => ballPosition.transform.position.x).ToList();
				
				foreach(GameObject ball in balls)
				{
					int i = 0;
					int movemant = 0;
					int ballPositionX = (int)Mathf.Round((ball.GetComponent<Transform>().position.x/1f)+2);
					int ballPositionY = 4-((int)Mathf.Round((ball.GetComponent<Transform>().position.y/1f)+2));

					while(i != ballPositionX)
					{
						if(gridControler.grid[i,ballPositionY] == 2 || gridControler.grid[i,ballPositionY] == -1)
						{
							movemant = 0;
						}
						else
						{
							movemant++;
						}
						i++;		
					}
					
					Vector3 ballFinalPosition = new Vector3(
						ball.GetComponent<Transform>().position.x - (1f*movemant),
						ball.GetComponent<Transform>().position.y,
						0
					);

					ballsToMove.Add(ball);
					ballDestinations.Add(ballFinalPosition);
					ballStartPositions.Add(ball.GetComponent<Transform>().position);

					gridControler.grid[ballPositionX, ballPositionY] = 0;
					gridControler.grid[ballPositionX-movemant, ballPositionY] = -1;
				}
				counter = timer;
			}

			else if(swipeControler.swipeRight)
			{
				balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));

				balls = balls.OrderBy(ballPosition => ballPosition.transform.position.x).ToList();
				balls.Reverse();

				foreach(GameObject ball in balls)
				{
					int i = 4;
					int movemant = 0;
					int ballPositionX = (int)Mathf.Round((ball.GetComponent<Transform>().position.x/1f)+2);
					int ballPositionY = 4-((int)(Mathf.Round(ball.GetComponent<Transform>().position.y/1f)+2));

					while(i != ballPositionX)
					{
						if(gridControler.grid[i,ballPositionY] == 2 || gridControler.grid[i,ballPositionY] == -1)
						{
							movemant = 0;
						}
						else
						{
							movemant++;
						}
						i--;		
					}

					Vector3 ballFinalPosition = new Vector3(
						ball.GetComponent<Transform>().position.x + (1f*movemant),
						ball.GetComponent<Transform>().position.y,
						0
					);
					
					ballsToMove.Add(ball);
					ballDestinations.Add(ballFinalPosition);
					ballStartPositions.Add(ball.GetComponent<Transform>().position);

					gridControler.grid[ballPositionX, ballPositionY] = 0;
					gridControler.grid[ballPositionX+movemant, ballPositionY] = -1;
				}
				counter = timer;
			}

			else if(swipeControler.swipeUp)
			{	
				balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));

				balls = balls.OrderBy(ballPosition => ballPosition.transform.position.y).ToList();
				balls.Reverse();

				foreach(GameObject ball in balls)
				{
					int i = 0;
					int movemant = 0;
					int ballPositionX = (int)(Mathf.Round(ball.GetComponent<Transform>().position.x/1f)+2);
					int ballPositionY = 4-((int)Mathf.Round((ball.GetComponent<Transform>().position.y/1f)+2));

					while(i != ballPositionY)
					{
						if(gridControler.grid[ballPositionX,i] == 2 || gridControler.grid[ballPositionX,i] == -1)
						{
							movemant = 0;
						}
						else
						{
							movemant++;
						}
						i++;		
					}

					Vector3 ballFinalPosition = new Vector3(
						ball.GetComponent<Transform>().position.x,
						ball.GetComponent<Transform>().position.y + (1f*movemant),
						0
					);
					
					ballsToMove.Add(ball);
					ballDestinations.Add(ballFinalPosition);
					ballStartPositions.Add(ball.GetComponent<Transform>().position);

					gridControler.grid[ballPositionX, ballPositionY] = 0;
					gridControler.grid[ballPositionX, ballPositionY-movemant] = -1;
				}
				counter = timer;
			}

			else if(swipeControler.swipeDown)
			{
				balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));

				balls = balls.OrderBy(ballPosition => ballPosition.transform.position.y).ToList();

				foreach(GameObject ball in balls)
				{
					int i = 4;
					int movemant = 0;
					int ballPositionX = (int)Mathf.Round((ball.GetComponent<Transform>().position.x/1f)+2);
					int ballPositionY = 4-(int)Mathf.Round((ball.GetComponent<Transform>().position.y/1f)+2);

					while(i != ballPositionY)
					{
						if(gridControler.grid[ballPositionX,i] == 2 || gridControler.grid[ballPositionX,i] == -1)
						{
							movemant = 0;
						}
						else
						{
							movemant++;
						}
						i--;		
					}

					Vector3 ballFinalPosition = new Vector3(
						ball.GetComponent<Transform>().position.x,
						ball.GetComponent<Transform>().position.y - (1f*movemant),
						0
					);

					ballsToMove.Add(ball);
					ballDestinations.Add(ballFinalPosition);
					ballStartPositions.Add(ball.GetComponent<Transform>().position);

					gridControler.grid[ballPositionX, ballPositionY] = 0;
					gridControler.grid[ballPositionX, ballPositionY+movemant] = -1;
				}
				counter = timer;
			}
			
			else
			{
				counter = 0;
			}
		}

		if(ballsToMove.Count != 0 && ballDestinations.Count != 0 && ballStartPositions.Count != 0)
		{

			int f = 0;
			foreach(GameObject ball in ballsToMove)
			{
				ball.GetComponent<Transform>().position -= 
				(ballStartPositions[f] - ballDestinations[f])/(timer+1);
				if(ballStartPositions[f] - ballDestinations[f] != Vector3.zero)
				{
					playSwipeSound = true;
				}
				f++;
			}
			
			if (counter == timer && playSwipeSound)
			{
				GameObject.Find("GameSounds").GetComponents<AudioSource>()[1].pitch = Random.Range(0.9f, 1.1f);
				GameObject.Find("GameSounds").GetComponents<AudioSource>()[1].Play();
			}
			playSwipeSound = false;
			

			if (counter == 0)
			{
				SendMessage("CheckWinCondition");
				ballsToMove.Clear();
				ballDestinations.Clear();
				ballStartPositions.Clear();
			}
		}


	}
}
