using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Case : MonoBehaviour
{
    // Start is called before the first frame update
     public bool isPull;
     private bool TouchCase;
     public Vector3 PlayerPosition;
     public Vector3 PlayerLocalScale;
     public float Direction;
     public GameObject Player;
     private Rigidbody2D rb;

     [Header("碰撞判断")]
     public float CaseOffsetX = 0.6f;
     public float CaseOffsetY = 0f;
     public float length = 1f;
     public LayerMask groundLayer;
     public GameObject Dialog;
     private bool showDialog=false;
     public  bool Flag = false;

     public dataSave saveData;
     public bool firstLoad=true;
     public bool needSave;
    void Start()
    {
        Player=GameObject.Find("player"); 
        rb = GetComponent<Rigidbody2D>();
        if(!firstLoad)
        {
            gameObject.transform.position=saveData.itemList[1];

        }
        firstLoad=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Player.GetComponent<playermove>().transform.position;
        PlayerLocalScale = Player.GetComponent<playermove>().transform.localScale;

        Direction = Player.GetComponent<playermove>().direction;
        Vector2 OffsetR = new Vector2(CaseOffsetX, CaseOffsetY);
        Vector2 OffsetL = new Vector2(CaseOffsetX*-1, CaseOffsetY);
        RaycastHit2D RightCheck = Raycast(OffsetR, Vector2.right, length, groundLayer);
        RaycastHit2D LeftCheck = Raycast(OffsetL, Vector2.left, length, groundLayer);

        if(Input.GetButton("Pull"))
        {
            isPull = true;
        }
        else
        {
            isPull = false;
        }

        if((LeftCheck || RightCheck) && !Flag)
        {

            TouchCase = true;
            Flag = true;
            Player.GetComponent<playermove>().isTouchCase = true;
            if(!showDialog)
            {
                Dialog.SetActive(true);
            }
            else
            {
                Destroy(Dialog);
            }
        }
        else if((!LeftCheck && !RightCheck) && Flag)
        {
            Flag = false;
            TouchCase = false;
            Player.GetComponent<playermove>().isTouchCase = false;  
            Dialog.SetActive(false);         
        }
        //transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, 0.01f);
   

        if (isPull && TouchCase)
        {
            showDialog=true;
            transform.position = PlayerPosition +  new Vector3(1.2f * PlayerLocalScale.x,0f,0f);
            rb.gravityScale = 0;
        }
        else if (!isPull || !TouchCase)
            rb.gravityScale = 500;

        if(changeSenes.afterChange)
        {
            gameObject.transform.position=saveData.itemList[1];
            changeSenes.afterChange=false;
        }
        saveSense();
        
    }

    

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length,color);
        return hit;
    }

    void saveSense()
    {
        
        for(int i=0;i<saveData.taglist.Count;i++)
        {
            if(saveData.taglist[i]=="Box")
            {
                saveData.itemList[i]=gameObject.transform.position;

            }
            
        }
        
    }
}
