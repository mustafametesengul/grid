using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	public bool sound = true;

	void Awake() 
    {
        Application.targetFrameRate = 30;

    }

    void Start()
    {
        Invoke("DestroyFirstAnim",6);

        if(gameObject.GetComponent<LevelSelection>().lastLevel == 1)
        {
            GameObject.Find("MenuTab").GetComponent<Animator>().Play("menuOpen");
            GameObject.Find("GameEngine").GetComponent<Menu>().openable= false;
            GameObject.Find("GameEngine").GetComponent<Refresh>().openable = false;
            Invoke("CloseInstructions", 7);
            Invoke("DestroyInstructions", 8);
        }
        else{
            Destroy(GameObject.Find("Instructions"));
        }
        
    }

    void DestroyFirstAnim()
    {
        Destroy(GameObject.Find("Phi"));
        Destroy(GameObject.Find("Black"));
    }

    void CloseInstructions()
    {
        gameObject.GetComponent<Menu>().openable = true;
        gameObject.GetComponent<Refresh>().openable = true;
        GameObject.Find("MenuTab").GetComponent<Animator>().Play("menuClose");
        Invoke("PlayTheSound",0.1f);
        
    }

    void DestroyInstructions()
	{
        Destroy(GameObject.Find("Instructions"));
    }
    void PlayTheSound()
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameObject.GetComponent<Menu>().openState == true)
            {
                gameObject.GetComponent<Menu>().OpenCloseMenu();
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
