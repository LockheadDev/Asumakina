
using UnityEngine;
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
            FindObjectOfType<SoundMng>().Stop("Music2");
        }
        else
        {
            GameOvermessage.SetActive(false);
            GUIInGame.SetActive(true);
        }
    }


}
