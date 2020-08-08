using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doOpenURL : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    public void OpenURL()
    {
        Application.OpenURL(url);
        Debug.Log("Opening feedback link...");
    }
}
