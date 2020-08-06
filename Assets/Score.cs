using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float scoreValue = 0;
    private float megaScore;
    private float score;
    public TextMeshProUGUI scoreText;
    

    // Update is called once per frame
    void Update()
    {
        if(scoreText ==null)
        {
            gameObject.AddComponent<TextMeshProUGUI>();
        }
        scoreText.color = Color.white;
        scoreText.text = scoreValue.ToString();
        if (scoreValue > PlayerPrefs.GetFloat("HighScore", 0F))
        {
            
            PlayerPrefs.SetFloat("HighScore",scoreValue);
        }
        if (scoreValue == PlayerPrefs.GetFloat("HighScore"))
        {
            scoreText.color=Color.yellow;
        }
    }
    public void AddScore(float newScore)
    {
        if(megaScore==0)
        {
         score += newScore;
         megaScore=1;
         StartCoroutine ("MultiScoreThing");
     }
     else if(megaScore==1)
     {
         score += newScore + 1;
         megaScore=2;
         StopCoroutine ("MultiScoreThing");
     }
     else if(megaScore==2)
     {
         score += newScore + 2;
         megaScore=3;
         StopCoroutine ("MultiScoreThing");
     }
     UpdateScore ();
     StartCoroutine("MultiScoreThing");
 }

 IEnumerator MultiScoreThing ()
 {
     yield return new WaitForSeconds (4);
     megaScore = 0;
 }

 void UpdateScore()
 {
     scoreValue=score;
 }
}
