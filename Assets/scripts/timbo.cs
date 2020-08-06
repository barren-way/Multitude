using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timbo : MonoBehaviour
{
    public float climbspeed = 2f;
    private bool inLadder;
    public Collider2D platf;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag =="Player")
        {
            //向上爬
            if(Input.GetButton("Jump"))
            {
                inLadder=true;
                collider.GetComponent<Rigidbody2D>().gravityScale=0;
                collider.GetComponent<Rigidbody2D>().velocity =new Vector2(0,climbspeed);
            }
            //向下爬
            else if (Input.GetButton("Crouch"))
            {
                inLadder=true;
                collider.GetComponent<Rigidbody2D>().gravityScale=0;
                collider.GetComponent<Rigidbody2D>().velocity =new Vector2(0,-climbspeed);
            }
            else if(Input.GetKey(KeyCode.Space))
            {
                collider.GetComponent<Rigidbody2D>().gravityScale = 1;
                inLadder = false;
            }
            else if(inLadder)
            {
                collider.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        collider.GetComponent<Rigidbody2D>().gravityScale=1;
        inLadder = false;
    }
}
