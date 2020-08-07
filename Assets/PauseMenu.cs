using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        optionsMenu.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu");
        FindObjectOfType<SceneTransition>().LoadPreviousLevel();
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        FindObjectOfType<SceneTransition>().Reload();
        Debug.Log("Restarting");
        Time.timeScale = 1f;
    }
}
