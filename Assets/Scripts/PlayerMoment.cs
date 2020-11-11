using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float moveSpeed;

    private Vector2 startPoint = Vector2.zero;
    private Vector2 currentPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Movement();

    }
    void Movement()
    {
#if UNITY_EDITOR
        if (Input.GetAxis("Horizontal") > 0f)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
#elif UNITY_ANDROID
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startPoint = touch.position;
                break;
            case TouchPhase.Moved:
                currentPoint = touch.position;
                if (startPoint.x > currentPoint.x && transform.position.x >= -2f)
                {
                    float hor = startPoint.x - currentPoint.x;
                    transform.Translate(Vector2.left * (hor / 10) * moveSpeed * Time.deltaTime);
                }
                else if (startPoint.x < currentPoint.x && transform.position.x < 2f)
                {
                    float hor = currentPoint.x - startPoint.x;
                    transform.Translate(Vector2.right * (hor / 10) * moveSpeed * Time.deltaTime);
                }
                startPoint = currentPoint;
                break;

            case TouchPhase.Ended:
                startPoint = Vector2.zero;
                currentPoint = Vector2.zero;
                break;
        }
#endif

    }
    public void PlatformMove(float x)
    {
        rb2d.velocity = new Vector2(x, rb2d.velocity.y);
    }

}



