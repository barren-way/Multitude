using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    // Start is called before the first frame update
    public int num=0;
    public float startPosition;
    public int distance=83;
    void Start()
    {
        startPosition=gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(num==5)
            {
                num=0;
                gameObject.transform.position=new Vector3(startPosition,gameObject.transform.position.y,gameObject.transform.position.z);
            }
            
            else
            {
                num++;
                gameObject.transform.position=new Vector3(gameObject.transform.position.x+distance,gameObject.transform.position.y,gameObject.transform.position.z);
            }
        }

    }
}
