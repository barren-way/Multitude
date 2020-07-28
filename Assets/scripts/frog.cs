using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : enemy
{

    private Rigidbody2D rb;
    private Collider2D coll;
    //private Animator anim;
    public LayerMask ground;
    public Transform leftpoint,rightpoint;
    public float speed,jumpForce;
    private bool faceleft=true;
    public float leftx,rightx;



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
        SwitchAnim();
    }

    void movement()
    {
        if(faceleft)
        {
            if(coll.IsTouchingLayers(ground))
            {
                anim.SetBool("jumping",true);
                rb.velocity=new Vector2(-speed,jumpForce);
            }
            if(transform.position.x<leftx)
            {
                transform.localScale = new Vector3(-1,1,1);
                faceleft=false;
            }
        }
        else
        {
            if(coll.IsTouchingLayers(ground))
            {
                anim.SetBool("jumping",true);
                rb.velocity=new Vector2(speed,jumpForce);
            }
            
            if(transform.position.x>rightx)
            {
                transform.localScale = new Vector3(1,1,1);
                faceleft=true;
            }

        }
    }

    void SwitchAnim()
    {
        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y<0.1f)
            {
                anim.SetBool("jumping",false);
                anim.SetBool("falling",true);
            }
            
        }
        if(coll.IsTouchingLayers(ground)&&anim.GetBool("falling"))
        {
            anim.SetBool("falling",false);
        }
    }

    

}
