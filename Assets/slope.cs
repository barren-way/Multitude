using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slope : MonoBehaviour
{
    // Start is called before the first frame updatevoid OnTriggerEnter2D(Collider2D other) 
    public bool onSlope;
     void OnTriggerStay2D(Collider2D other)

    {
        if(other.tag=="Player")
        {
            onSlope=true;
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            onSlope=false;
        }
    }
}
