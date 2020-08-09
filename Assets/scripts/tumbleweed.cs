using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumbleweed : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public LayerMask ground;
    public float speed,jumpForce;
    public bool up=false;


    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        if(coll.IsTouchingLayers(ground))
        {
            rb.velocity=new Vector2(-speed,rb.velocity.y);

            if(!up)
            {
                up=true;
                Invoke(nameof(jump),3);
            }
            
        }

    }

    void jump()
    {
        rb.velocity=new Vector2(rb.velocity.x,jumpForce);
        up=false;
    }
}
