
using UnityEngine;
using UnityEngine.Audio;
using System;


public class SoundMng : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundMng instance;
    // Start is called before the first frame update

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
        
        //Object Persists through scenes

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.vol;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }
    }

    void Start()
    {
        //PlaySound("Theme");
    }


    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds,Sound=>Sound.name == name);
        if(s == null)
        {
            Debug.Log("Sound: " + name + "not Found");
            return;
        }
        s.source.Play();

    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds,Sound=>Sound.name == name);
        if(s == null)
        {
            Debug.Log("Sound: " + name + "not Found");
            return;
        }
        s.source.Stop();

    }
}
