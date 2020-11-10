using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameManager instance;


  
    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

}
