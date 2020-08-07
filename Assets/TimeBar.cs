using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    public float maxTime =5f;
    public float timeSpeed =1f;
    public bool isConsuming;
    public float waitForEnable=3f;
    public float slowFilling =4f;
    public bool stop=false;

    private bool isTimeUp;
    private float timeLeft;
    private Image image;

    [HideInInspector]
    public bool isConsumeEnabled;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if(image==null)
        {
            image = gameObject.AddComponent<Image>();
        }

        isTimeUp = false;
        isConsuming = false;
        timeLeft=maxTime;
        isConsumeEnabled =true;
    }
public void StopFilling()
{
    stop =true;
}
public void ResumeFilling()
{
    stop = false;
}
    // Update is called once per frame
    void Update()
    {
        if(!stop)
        {
        timeLeft = Mathf.Clamp(timeLeft,0,maxTime);
        if(isConsumeEnabled)
        {
        if(timeLeft>0 && isConsuming)
        {
            timeLeft -=Time.unscaledDeltaTime*timeSpeed;
        }
        else if(timeLeft>0 && !isConsuming)
        {
            timeLeft +=Time.unscaledDeltaTime*timeSpeed/slowFilling;
        }
        else if (timeLeft==0)
        {
            isConsumeEnabled=false;
            isTimeUp=true;
        }
        }
        if(!isConsumeEnabled)
        {
            timeLeft +=Time.unscaledDeltaTime*timeSpeed;
            image.color = Color.gray;
            Debug.Log("timeLeft: "+timeLeft+ "maxtime"+maxTime);
            if(timeLeft>=maxTime)
            {
                image.color = Color.white;
                isConsumeEnabled=true;
                isTimeUp=false;
            }
        }
        image.fillAmount=timeLeft/maxTime;
        }
    }

    public bool getIsTimeUp()
    {
        return isTimeUp;
    }
}
