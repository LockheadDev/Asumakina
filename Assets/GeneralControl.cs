using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralControl : MonoBehaviour
{
    
    public bool onPause = false;
    public GameObject pauseMenu;
    

    void Awake()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !onPause)
        {
            onPause =true;
            FindObjectOfType<TimeManager>().Pause();

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && onPause)
        {
            onPause =false;
            FindObjectOfType<TimeManager>().Resume();
        }
        if(Input.GetKey(KeyCode.R))
        {
            FindObjectOfType<SceneTransition>().Reload();
        }
         if(Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
        }


    }
}
