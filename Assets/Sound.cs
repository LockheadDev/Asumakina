using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup output;

    [Range(0f,1f)]
    public float vol = 1f;
    [Range(0.1f,3f)]
    public float pitch = 1.5f;

    public bool loop;
    

    [HideInInspector]
    public AudioSource source;

}
