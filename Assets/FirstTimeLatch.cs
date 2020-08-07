using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeLatch : MonoBehaviour
{
    public GameObject[] hidelist;
    public GameObject[] showlist;
    private int firstRun =0;
    // Start is called before the first frame update
    void Start()
    {
        firstRun = PlayerPrefs.GetInt("firstRun",0);
        if(firstRun==0)
        {
            firstRun=1;
            PlayerPrefs.SetInt("firstRun",1);
            for(int i=0; i<hidelist.Length;i++)
            {
                hidelist[i].SetActive(false);
            }

            for(int i=0 ; i<showlist.Length;i++)
            {
                showlist[i].SetActive(true);
            }
        }
        else
        {
        for(int i=0; i<hidelist.Length;i++)
            {
                hidelist[i].SetActive(true);
            }

            for(int i=0 ; i<showlist.Length;i++)
            {
                showlist[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
}
