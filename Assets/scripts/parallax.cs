using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform cam;
    public float moveRate;
    public float changeNum;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(changeNum+cam.position.x*moveRate,transform.position.y);
    }

}
