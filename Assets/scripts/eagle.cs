using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : enemy
{
    private Rigidbody2D rb;
    private Collider2D coll;
    //private Animator anim;

    public Transform uppoint,downpoint;
    public float speed;
    public bool faceup=true;
    public float upy,downy;

    protected override void Start()
    {
        base.Start();
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        upy=uppoint.position.y;
        downy=downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        if(faceup)
        {
            rb.velocity=new Vector2(rb.velocity.x,speed);
            if(transform.position.y>upy)
            {
                faceup=false;
            }
        }
        else
        {

            rb.velocity=new Vector2(rb.velocity.x,-speed);
            if(transform.position.y<downy)
            {
                faceup=true;
            }

        }
    }
}
