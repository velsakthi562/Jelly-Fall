using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private float timer;
    private bool isGameOver;

    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        if(scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            if (isGameOver == false)
            {
                timer += Time.deltaTime;

                if (timer >= 1)
                {
                    score++;
                    scoreText.text = "Score : " + score;

                    timer = 0f;
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("HIGHSCORE"))
                {
                    if (score > PlayerPrefs.GetInt("HIGHSCORE"))
                    {
                        PlayerPrefs.SetInt("HIGHSCORE", score);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("HIGHSCORE", score);
                }
            }
        }

        if (Input.GetKey(KeyCode.Escape))
            Pasue();
    }

    public void SetGameOver(bool value)
    {
        isGameOver = value;
    }
    void Pasue()
    {
        if (isPause == false)
        {
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
        }
    }
    
}
