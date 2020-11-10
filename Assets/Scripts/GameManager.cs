using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    /*public static GameManager instance;
  
    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
