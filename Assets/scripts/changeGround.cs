using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ground;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Player")
        {
            ground.GetComponent<Collider2D>().isTrigger=false;
            Destroy(gameObject);
        }
    }
}
