using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSenes : MonoBehaviour
{

    public float changeSenseHight;
    public int levelNum = 1;
    static public bool getSword = true;
    public GameObject box;
    public dataSave saveData;
    static public bool senesChanging=false,afterChange=false;
    public BoolData boolSave;
    public bool thirdSence=false;
    public GameObject positionDialog,checkDialog;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        levelNum=(SceneManager.GetActiveScene().buildIndex+3)/3;
        if(levelNum>2)
        {
            thirdSence=true;
        }
        /*if (SceneManager.GetActiveScene().name == "start")
        {

            SceneManager.LoadScene(0);
        }*/

    }
    void Update()
    {
        if(boolSave.itemList[0])
        {
            transition();
        }
    }

    void transition()
    {
        if (levelNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    senesChanging=true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    afterChange=true;
                }


            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    
                    gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    GameObject.Find("case");
                    afterChange=true;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == levelNum * 3 - 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
                    gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                }
                if (SceneManager.GetActiveScene().buildIndex == levelNum * 3 - 2)
                {
                    
                    if(thirdSence)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
                        gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    }
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                }

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (SceneManager.GetActiveScene().buildIndex == levelNum * 3 - 3)
                {
                    if(thirdSence)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                        gameObject.transform.position += new Vector3(0, changeSenseHight, 0);
                    }
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
            levelNum += 1;
            if (levelNum == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }

        }
        
    }
    void  OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="thirdSence")
        {
            
            if(Input.GetButton("Pull"))
            {
                thirdSence=true;
                checkDialog.SetActive(false);
                positionDialog.SetActive(true);
            }
        }
    }
    
}
