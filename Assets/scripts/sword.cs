﻿using System.Collections.Concurrent;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosionVFXPrefab;
    public GameObject dialog;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
             Instantiate(explosionVFXPrefab,transform.position,transform.rotation);
             dialog.SetActive(true);
             Destroy(gameObject);
             changeSenes.getSword=true;
             playermove.PlayOrbAudio();  
                                    
        }
    }


}
