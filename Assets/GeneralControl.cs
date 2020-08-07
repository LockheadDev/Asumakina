using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralControl : MonoBehaviour
{
    
    public bool onPause = false;
    public GameObject pauseMenu;
    public GameObject HUD;
    public DragNShoot control;
    public TimeBar timeBar;

    private int currentScene;
    

    void Awake()
    {
        
         HUD.SetActive(true);
         pauseMenu.SetActive(false);
    }
    void Start()
    {
        //SceneManager.get
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !onPause)
        {
            control.disableControls=true;
           Pause();
           
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && onPause)
        {
          Resume();
          control.disableControls=false;
        }
        if(Input.GetKey(KeyCode.R))
        {
            FindObjectOfType<SceneTransition>().Reload();
            FindObjectOfType<SoundMng>().Stop("Music2");
        }
         if(Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        onPause =false;
        FindObjectOfType<TimeManager>().Resume();
        timeBar.ResumeFilling();
    
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        onPause =true;
        FindObjectOfType<TimeManager>().Pause();
        timeBar.StopFilling();
        control.CleanControls();
    }
}
