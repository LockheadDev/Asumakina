using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;

    public Text score;
    

    // Update is called once per frame
    void Update()
    {
        if(score ==null)
        {
            return;
        }
        score.color = Color.white;
        score.text = scoreValue.ToString();
        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore",scoreValue);
        }
        if (scoreValue == PlayerPrefs.GetInt("HighScore"))
        {
            score.color=Color.cyan;
        }
    }

}
