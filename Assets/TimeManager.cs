
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownfactor =0.02f;
    public float slowdownLength =2f;

    void Update()
    {
        Time.timeScale += (1f/slowdownLength)*Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    }

    public void doSlowMotion()
    {
        Time.timeScale = slowdownfactor;
        Time.fixedDeltaTime = Time.timeScale*0.02f;

    }
}
