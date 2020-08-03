using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    private static bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        SpawningEnemies.onOff = true;
        SpawningPowerUps.onOff = true;
        gameOver = false;
        GameOvermess.gamOv = false;
        Score.scoreValue =0;
    }

    public static bool getgameOver()
    {
        return gameOver;
    }

    public static void setgameOver(bool gO)
    {
        gameOver = gO;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            GameOvermess.gamOv = true;
            SpawningEnemies.onOff = false;
            SpawningPowerUps.onOff = false;
            if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Return))
            {
                FindObjectOfType<SceneTransition>().Reload();
            }
        }

        if (Time.timeScale == 0.0f)
        {
            Debug.Log("eNTERING...");
            if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Return))
            {
                Time.timeScale = 1;
                FindObjectOfType<SceneTransition>().Reload();

            }
        }
    }

    /*public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.scoreValue = 0;
        gameOver = false; 
    }

    public static void cleanScene()
    {
        Score.scoreValue = 0;
    }*/
}
