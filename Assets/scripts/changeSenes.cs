using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSenes : MonoBehaviour
{

    public float changeSenseHight;
    public int levelNum = 1;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == "start")
        {

            SceneManager.LoadScene(0);
        }

    }
    void Update()
    {
        if (levelNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                }

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                }
            }
        }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SceneManager.GetActiveScene().buildIndex == levelNum*3-2)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
                        gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    }

                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (SceneManager.GetActiveScene().buildIndex == levelNum*3-4)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
                        gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    }
                }


            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "passLine")
            {
                levelNum+=1;
                if(levelNum==2)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
                }
                
            }
        }
    }
