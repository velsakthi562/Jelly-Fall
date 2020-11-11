using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public float min_X = -2.5f, max_X = 2.5f, min_Y = -5.6f;
    private bool outOfRange;
    private bool isGameOver;

    public BacgroundController bacgroundController;
    public PlatformSpawner platformSpawner;
    public ScoreManager scoreManager;

    private void Start()
    {
        isGameOver = false;
        bacgroundController.SetGameOver(isGameOver);
        platformSpawner.SetGameOver(isGameOver);
        scoreManager.SetGameOver(isGameOver);
    }
    void Update()
    {
        CheckRange();
    }

    void CheckRange()
    {

        Vector2 temp = transform.position;

        if (temp.x > max_X)
            temp.x = max_X;

        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp;

        if (temp.y <= min_Y)
        {

            if (!outOfRange)
            {
                outOfRange = true;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spikes")
        {
            isGameOver = true;
            bacgroundController.SetGameOver(isGameOver);
            platformSpawner.SetGameOver(isGameOver);
            scoreManager.SetGameOver(isGameOver);

            Destroy(gameObject);
        }
    }
}
