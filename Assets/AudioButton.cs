
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    private AudioChanger audioChanger;
    public GameObject cross;

    // Start is called before the first frame update
    void Start()
    {
        audioChanger = FindObjectOfType<AudioChanger>();
        cross.SetActive(false);
        if(audioChanger==null)
        {
            Debug.Log("Audio Changer not found");
        }
    }

    public void modMusic()
    {
        Debug.Log("eneter");

        if(cross.activeSelf)
        {
            audioChanger.MusicVol(true);
            cross.SetActive(false);
        }
        else if(!cross.activeSelf)
        {
            audioChanger.MusicVol(false);
            cross.SetActive(true);
        }
        
    }
    
     public void modFX()
    {
        if(cross.activeSelf)
        {
            audioChanger.FXVol(true);
            cross.SetActive(false);
        }
        else if(!cross.activeSelf)
        {
            audioChanger.FXVol(false);
            cross.SetActive(true);
        }
    }
    
}
