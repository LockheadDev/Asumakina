using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChanger : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool MusicIsOn= true;
    public bool FXIsOn =true;
    public static AudioChanger instance;


    void Awake()
    {
        //Taking care of just spawning one SOundMng
        if(instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            //We write return to make sure any code is called
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(FXIsOn)
       {
           audioMixer.SetFloat("VolumeFX",0);
       }
       else if(!FXIsOn)
       {
            audioMixer.SetFloat("VolumeFX",-80);
       }
       if(MusicIsOn)
       {
           audioMixer.SetFloat("VolumeMusic",0);
       }
       else if(!MusicIsOn)
       {
           audioMixer.SetFloat("VolumeMusic",-80);
       }
    }

   public void ChangeFXPitch()
   {

   }
   public void ChangeMusicPitch()
   {
       
   }

   public void FXVol(bool state)
   {
       FXIsOn = state;
   }

   public void MusicVol(bool state)
   {
       MusicIsOn = state;
   }
}
