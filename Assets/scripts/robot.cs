using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : enemy
{
    private Rigidbody2D rb;
    private Collider2D coll;
    //private Animator anim;
    public GameObject player;

    public Transform rightpoint,leftpoint;
    public float speed;
    public bool faceright=true;
    public float rightx,leftx;

    protected override void Start()
    {
        base.Start();
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        leftx=leftpoint.position.x;
        rightx=rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        if(faceright)
        {
            rb.velocity=new Vector2(rb.velocity.y,speed);
            if(transform.position.x>rightx)
            {
                
                transform.localScale = new Vector3(-1,1,1);
                faceright=false;
            }
        }
        else
        {

            rb.velocity=new Vector2(-speed,rb.velocity.y);
            if(transform.position.x<leftx)
            {
                transform.localScale = new Vector3(1,1,1);
                faceright=true;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            transform.localScale = new Vector3(-1,1,1);
            faceright=false;
            anim.SetBool("fight",true);           
        }
    }

    void afterFight()
    {
        anim.SetBool("fight",false);
        Destroy(player);
    }
}
