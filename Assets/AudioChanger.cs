using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChanger : MonoBehaviour
{
    public AudioMixer audioMixer;
    private bool MusicIsOn= true;
    private bool FXIsOn =true;
    public static AudioChanger instance;

    private float startingMusicPitch;


    void Awake()
    {
    audioMixer.GetFloat("PitchMusic",out startingMusicPitch);
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

    }

    float SuperLerp(float from,float to, float from2, float to2,float value) {
    if (value <= from2)
        return from;
    else if (value >= to2)
        return to;
    return (to - from) * ((value - from2) / (to2 - from2)) + from;
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
       float currentPitch = Time.timeScale;
       currentPitch = SuperLerp(0.7f,startingMusicPitch,0F,1F,currentPitch);
       if(Time.timeScale==0)
       {
           currentPitch =0F;
       }
       

       //currentPitch = Mathf.Clamp(currentPitch,0.85F,startingMusicPitch);
       audioMixer.SetFloat("PitchMusic", currentPitch);
    }

   public void ChangeFXPitch()
   {

   }

   public void FXVol(bool state)
   {
       Debug.Log("FXvol:"+state);
       FXIsOn = state;
   }

   public void MusicVol(bool state)
   {
        Debug.Log("Musicvol:"+state);
       MusicIsOn = state;
   }
}
