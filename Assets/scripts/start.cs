using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        Player=GameObject.Find("player"); 
    }
    public void playgame()
    {
        Player.GetComponent<playermove>().isStart = true;
        SceneManager.LoadScene(1);
    }
}
