
using UnityEngine;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour
{
    public float slowdownfactor =0.02f;
    public float slowdownLength =2f;
    private bool isPaused = false;
    public AudioMixer AudioMix;
 



    void Update()
    {
        
        isPaused = FindObjectOfType<GeneralControl>().onPause;
        if(!isPaused){

        
        Time.timeScale += (1f/slowdownLength)*Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
        }


    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void doSlowMotion()
    {
        FindObjectOfType<SoundMng>().PlaySound("SlowDown");
        Time.timeScale = slowdownfactor;
        Time.fixedDeltaTime = Time.timeScale*0.02f;
    }
}
