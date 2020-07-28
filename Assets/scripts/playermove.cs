
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anima;
    public AudioSource jumpAudio,deadAudio;


    public float speed=10f;
    public float jumpforce;
    
    public LayerMask ground;
    public Collider2D coll;
    public Collider2D disColl; 
    public Transform ceilingCheck;
    public int cherry;
    public Text cherryNum;
    public bool isHurt;

    public Transform groundCheck;
    public bool isGround,isJump;
    bool jumpPress;
    int jumpCount;


    
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anima=GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if(Input.GetButtonDown("Jump")&&jumpCount>0)
        {
            jumpPress=true;
        }
    }
    void FixedUpdate()
    {
        if (!isHurt)
        {
            isGround=Physics2D.OverlapCircle(groundCheck.position,0.1f,ground);
            Movement();
            jump();
        }   
        SwitchAnim();
    }

    void Movement()
    {
        float horizontalmove=Input.GetAxisRaw("Horizontal");
        float facedircetion = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalmove*speed,rb.velocity.y);
        anima.SetFloat("running",Mathf.Abs(facedircetion));
        //角色移动

        if (facedircetion!=0)
        {
           transform.localScale = new Vector3(facedircetion,1,1); 
        }
        //角色跳跃
        /*if (Input.GetButtonDown("Jump")&& coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpforce*Time.fixedDeltaTime);
            anima.SetBool("jumping",true);
            jumpAudio.Play();
        }*/
        couch();


    }
    void jump()
    {
        if(isGround)
        {
            jumpCount=1;
            isJump=false;
        }
        if(jumpPress&&isGround)
        {
            isJump=true;
            rb.velocity=new Vector2(rb.velocity.x,jumpforce);
            jumpCount--;
            jumpPress=false;
        }
        else if(jumpPress&&jumpCount>0&&isJump)
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpforce);
            jumpCount--;
            jumpPress=false;
        }
    }

    //动画切换
    void SwitchAnim()
    {
        anima.SetBool("idle",false);
        if(rb.velocity.y<0.1f && !coll.IsTouchingLayers(ground))
        {
            anima.SetBool("jumping",false);
            anima.SetBool("falling",true);
        }
        if(anima.GetBool("jumping"))
        {
            if (rb.velocity.y<0)
            {
                anima.SetBool("jumping",false);
                anima.SetBool("falling",true);
            }
            
        }else if (isHurt)
        {
            anima.SetBool("hurt",true);
            anima.SetFloat("running",0);
            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                anima.SetBool("hurt",false);
                anima.SetBool("idle",true);
                isHurt=false;
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anima.SetBool("falling",false);
            anima.SetBool("idle",true);
        }
    }

    //收集物品
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="collection")
        {
            Destroy(collision.gameObject);
            cherry+=1;
            cherryNum.text=cherry.ToString();
        }
        if(collision.tag=="deadLine")
        {
            GetComponent<AudioSource>().enabled=false;
            deadAudio.Play();
            Invoke(nameof(restart),1);
        }
    }

    //消灭敌人
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
        if (collisionInfo.gameObject.tag=="enemy")
        {
           enemy enemy1 =collisionInfo.gameObject.GetComponent<enemy>();
           if(anima.GetBool("falling"))
            {
                enemy1.jumpOn();
                
                rb.velocity = new Vector2(rb.velocity.x,jumpforce*Time.deltaTime);
                anima.SetBool("jumping",true);
            } 
            else if (transform.position.x<collisionInfo.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-5,rb.velocity.y);
                isHurt=true;
            }
             else if (transform.position.x>collisionInfo.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5,rb.velocity.y);
                isHurt=true;
            }
        }
        
    }
    void couch()
    {
        float crouchTime=Input.GetAxis("Crouch");
        if(!Physics2D.OverlapCircle(ceilingCheck.position,0.2f,ground))
        {
            if(crouchTime!=0)
            {
                anima.SetBool("crouching",true);
                disColl.enabled=false;
            }
            else
            {
                anima.SetBool("crouching",false);
                disColl.enabled=true;
            }
        
        }
        
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
