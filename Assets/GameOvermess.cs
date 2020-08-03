using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOvermess : MonoBehaviour
{
    public static bool gamOv= false;

    public GameObject GameOvermessage;

    public GameObject GUIInGame;
    
    // Update is called once per frame
    void Update()
    {
        if (gamOv)
        {

            GameOvermessage.SetActive(true);
            GUIInGame.SetActive(false);
            FindObjectOfType<SoundMng>().Stop("GameTheme");
        }
        else
        {
            GameOvermessage.SetActive(false);
            GUIInGame.SetActive(true);
        }
    }


}
