using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform uppoint,downpoint;
    private Rigidbody2D rb;
    public GameObject Player;
    public float upy,downy;
    public float speed = 2f;
    public bool peng;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        upy=uppoint.position.y;
        downy=downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        if(Input.GetButton("Jump"))
        {
            //rb.velocity=new Vector2(speed,rb.velocity.y);
            if(transform.position.y < upy)
            {                
               rb.velocity=new Vector2(rb.velocity.x,speed);
            }
            else
            {
               rb.velocity=new Vector2(rb.velocity.x,0);
            }
        }
        else if(Input.GetButton("Crouch"))
        {

            //rb.velocity=new Vector2(-speed,rb.velocity.y);
            if(transform.position.y>downy)
            {
                rb.velocity=new Vector2(rb.velocity.x,-speed);
            }
            else
            {
               rb.velocity=new Vector2(rb.velocity.x,0);
            }

        }
        else
        {
            rb.velocity=new Vector2(rb.velocity.x,0);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=0;        
            peng = true; 
        }
    }
    void OnCollisionExit2D(Collision2D collider) 
    {
        collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=1;
    }

}
