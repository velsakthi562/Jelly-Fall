using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        if(highScoreText != null)
        {
            if (PlayerPrefs.HasKey("HIGHSCORE"))
            {
                highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HIGHSCORE");
            }
            else
            {
                highScoreText.text = "";
                Debug.Log("NO HIGHSCORE!");
            }
        }
        else
        {
            Debug.LogError("HighScoreText not Added in Field!");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
