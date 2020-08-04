using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopUP : MonoBehaviour
{
    private TextMeshPro tmp;

    void Awake()
    {
        tmp = transform.GetComponent<TextMeshPro>(); 
    }
    public void setInfo(string info)
    {
        transform.rotation =Quaternion.identity;
        tmp.SetText(info);
    }
}
