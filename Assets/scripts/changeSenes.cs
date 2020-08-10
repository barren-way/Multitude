using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSenes : MonoBehaviour
{

    public float changeSenseHight;
    void Awake()
    {
        DontDestroyOnLoad (gameObject);
        if(SceneManager.GetActiveScene().name=="start")
        {
            
            SceneManager.LoadScene(0);
        }

        
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E ))
        {
            if(SceneManager.GetActiveScene().buildIndex==0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                gameObject.transform.position+=new Vector3(0,changeSenseHight,0);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(SceneManager.GetActiveScene().buildIndex==1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
                gameObject.transform.position+=new Vector3(0,changeSenseHight,0);
            }
            
        }
    }
}
