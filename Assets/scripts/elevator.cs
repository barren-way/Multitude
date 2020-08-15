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
    public bool IsElevator;
    public bool Move;
    public bool Up,Down;
    //private PolygonCollider2D coll;
    public BoxCollider2D coll_right;
    public BoxCollider2D coll_left;
    public BoxCollider2D coll_up;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
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
        if(IsElevator)
        {
            if(Input.GetButton("Pull"))
            {
                Move = true;
                //rb.velocity=new Vector2(speed,rb.velocity.y);
                coll_right.isTrigger = false;
                coll_left.isTrigger = false;
                coll_up.isTrigger = false;
                if(transform.position.y < downy )
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;               
                    rb.velocity=new Vector2(rb.velocity.x,speed);
                    Up = true;
                    Down = false;
                }
                if(transform.position.y > upy)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.velocity=new Vector2(rb.velocity.x,-speed);
                    Up = false;
                    Down = true;
                }
            }
            if(transform.position.y > upy && rb.velocity.y > 0)
            {
                Move = false;
                rb.velocity=new Vector2(rb.velocity.x,0);
                rb.bodyType = RigidbodyType2D.Static;
                coll_right.isTrigger = true;
                coll_left.isTrigger = true;
                coll_up.isTrigger = true;
            }
            if(transform.position.y < downy && rb.velocity.y < 0)
            {
                Move = false;
                rb.velocity=new Vector2(rb.velocity.x,0);
                rb.bodyType = RigidbodyType2D.Static;
                coll_right.isTrigger = true;
                coll_left.isTrigger = true;
                coll_up.isTrigger = true;
            }
            if(Up && Move)
            {
                rb.velocity=new Vector2(rb.velocity.x,speed);
            }
            if(Down && Move)
            {
                rb.velocity=new Vector2(rb.velocity.x,-speed);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=0;        
            IsElevator= true; 
        }
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=0;        
            IsElevator= true; 
        }
    }
    void OnCollisionExit2D(Collision2D collider) 
    {
        collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=1;
        IsElevator = false;
    }

}
