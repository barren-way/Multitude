using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    public GameObject timbo;
    private Collider2D timboCollider;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        timbo=GameObject.Find("timbo");
        timboCollider=timbo.GetComponent<Collider2D>();
        rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }

    void check()
    {
        if (timboCollider.enabled==false)
        {
            rb.gravityScale=1;
            Invoke(nameof(destoryRock),5f);
        }
    }

    void destoryRock()
    {
        Destroy(gameObject);
    }
}
