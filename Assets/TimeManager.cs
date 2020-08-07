
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownfactor =0.02f;
    public float slowdownLength =2f;
    private bool isPaused = false;
 



    void Update()
    {
        isPaused = FindObjectOfType<GeneralControl>().onPause;
        if(!isPaused ){
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
        Time.timeScale = slowdownfactor;
        Time.fixedDeltaTime = Time.timeScale*0.02f;
    }
    public void doSlowMotionHard()
    {
        doSlowMotion();
    }
}
