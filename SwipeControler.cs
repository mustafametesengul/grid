using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControler : MonoBehaviour 
{
	public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private Vector2 startTouch, swipeDelta;
	private bool isDraging = false;

	
	void Update () 
	{
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;


		if(Input.GetKeyDown("left"))
		{
			swipeLeft = true;
		}
		else if(Input.GetKeyDown("right"))
		{
			swipeRight = true;
		}
		else if(Input.GetKeyDown("up"))
		{
			swipeUp = true;
		}
		else if(Input.GetKeyDown("down"))
		{
			swipeDown = true;
		}


		if(Input.touches.Length > 0)
		{
			if(Input.touches[0].phase == TouchPhase.Began)
			{
				tap = true;
				startTouch = Input.touches[0].position;
				isDraging = true;
			}
			else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				isDraging = false;
				Reset();
			}
		}

		swipeDelta = Vector2.zero;
		if(isDraging)
		{
			if(Input.touches.Length > 0)
			{
				swipeDelta = Input.touches[0].position - startTouch;
			}
		}

		if(swipeDelta.magnitude > 60)
		{
			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if(Mathf.Abs(x) > Mathf.Abs(y))
			{
				if(x < 0)
				{
					swipeLeft = true;
				}
				else{
					swipeRight = true;
				}
			}
			else
			{
				if(y < 0)
				{
					swipeDown = true;
				}
				else{
					swipeUp = true;
				}
			}


			Reset();
		}

	}

	void Reset()
	{
		startTouch = Vector2.zero;
		swipeDelta = Vector2.zero;
		isDraging = false;
	}
}
