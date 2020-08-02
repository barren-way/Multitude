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
     public bool isTouchCase;
     public Vector3 PlayerPosition;
     public GameObject Player;

     [Header("碰撞判断")]
     public float CaseOffsetX = 0.6f;
     public float CaseOffsetY = 0f;
     public float length = 0.5f;
     public LayerMask groundLayer;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Player.GetComponent<playermove>().transform.position;
        Vector2 OffsetR = new Vector2(CaseOffsetX, CaseOffsetY);
        Vector2 OffsetL = new Vector2(CaseOffsetX*-1, CaseOffsetY);
        RaycastHit2D RightCheck = Raycast(OffsetR, Vector2.right, length, groundLayer);
        RaycastHit2D LeftCheck = Raycast(OffsetL, Vector2.left, length, groundLayer);

        if(Input.GetButton("Pull"))
        {
            isPull = true;
        }

        if(LeftCheck || RightCheck)
        {
            isTouchCase = true;
        }
        else
        {
            isTouchCase = false;
        }
        //transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, 0.01f);
        if (isPull && isTouchCase)
            transform.position = PlayerPosition +  new Vector3(1.2f,0f,0f);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length,color);
        return hit;
    }
}
