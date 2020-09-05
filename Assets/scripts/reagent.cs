using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reagent : MonoBehaviour
{
    public GameObject explosionVFXPrefab;
    public GameObject useDialog;
    public GameObject Monkey;
    public int Catalyzer;

    private Animator anim;
    private bool flag;

     [Header("射线")]
     public float CaseOffsetX = 4.5f;
     public float CaseOffsetY = -0.4f;
     public float length = 2f;
     public LayerMask groundLayer;
     public Inventory myBag;
     public BoolData boolSave;
     public Item thisItem;
     public bool place;
     public Collider2D lightColl;
     public GameObject growLight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CreatRay();
        if( Input.GetKeyDown(KeyCode.R) && flag == true)   //使用机器
        {
            anim.SetBool("light",true); 
            Destroy(useDialog);
            //useDialog.SetActive(false); 
        }
        if( Input.GetButton("Pull")&& flag == true)  //收集机器
        {
             Instantiate(explosionVFXPrefab,transform.position,transform.rotation);
             playermove.PlayOrbAudio();
             Destroy(useDialog);             
             Destroy(gameObject); 
        }
    }
    //void OnCollisionEnter2D(Collision2D collider)
    //{

    //}

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length,color);
        return hit;
    }
    void CreatRay()
    {
        Vector2 OffsetR = new Vector2(CaseOffsetX-5, CaseOffsetY);
        Vector2 OffsetL = new Vector2(CaseOffsetX*-1, CaseOffsetY);
        RaycastHit2D RightCheck = Raycast(OffsetR, Vector2.right, length, groundLayer);
        RaycastHit2D LeftCheck = Raycast(OffsetL, Vector2.left, length, groundLayer);
        if(RightCheck || LeftCheck)
        {
            flag = true;
            if(!place)
            {
                useDialog.SetActive(true);
            }
              
        }
        else
        {
            flag = false;
            if(!place)
            {
                useDialog.SetActive(false);
            }

            
        }
    }

    void Aftermachine()
    {
        
        if(!place)
        {
            Monkey.GetComponent<monkey>().grow = true;
            place=true; 
        }
        
    }
    void lightOpen()
    {
        growLight.GetComponent<Collider2D>().enabled=true;
    }
}
