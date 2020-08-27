using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkUI;
    public GameObject Player;
    private bool flag;
    public bool isUI;
    // Update is called once per frame
    void Start() 
    {
        Player=GameObject.Find("player"); 
        flag = true;
    }
    void Update()
    {
        if(isUI && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        isUI = true;
        if(collider.tag =="Player" && flag == true)
        {
            //Player.GetComponent<playermove>().isStart = true;
            flag = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        isUI = false;
        //Player.GetComponent<playermove>().isStart = false;
    }

}
