using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    void Awake()
    {
        if (instance = null)
            instance = this;
    }
    
    public AudioSource audioSource;
    
    public AudioClip landClip;
    public AudioClip deathClip;
    public AudioClip iceBreakClip;
    public AudioClip gameOverClip;

   
    public void LandSound()
    {
        audioSource.clip = landClip;
        audioSource.Play();
    }
    public void IceBreak()
    {
        audioSource.clip = iceBreakClip;
        audioSource.Play();
    }
    public void Death()
    {
        audioSource.clip = deathClip;
        audioSource.Play();
    }
    public void GameOver()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}
