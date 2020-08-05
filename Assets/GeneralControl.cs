using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralControl : MonoBehaviour
{

    public bool onPause = false;

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
    }
}
