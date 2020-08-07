using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        FindObjectOfType<SceneTransition>().LoadNextLevel();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RefreshOptions()
    {
        FindObjectOfType<OptionsMenu>().Refresh();
    }

}
