using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public float moveSpeed;
    public float invisibleY = 6f;

    public bool movingPlatformLeft;
    public bool movingPlatformRight;
    public bool isBreaking;
    public bool isPlatform;
    public bool isSpike;

    private Animator animator;

    
    void Awake()
    {
        if (isBreaking)
            animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;
        if(temp.y>= invisibleY)
        {
            Destroy(gameObject);
        }
    }
    void BreakingDeactivate()
    {
        Invoke("DeactivateGameObject", 0.5f);
    }
    void DeactivateGameObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           if (isSpike)
            {
                collision.transform.position = new Vector2(1000f, 1000f);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isBreaking)
            {
                animator.Play("Break");
            }
            if (isPlatform)
            {
                //SoundManager.instance.LandSound();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (movingPlatformLeft)
            {
                collision.gameObject.GetComponent<PlayerMoment>().PlatformMove(-2f);

            }
            if (movingPlatformRight)
            {
                collision.gameObject.GetComponent<PlayerMoment>().PlatformMove(2f);

            }
        }
    }
}
