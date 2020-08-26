using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public GameObject timbo;
    public Collider2D timboCollider;
    public GameObject player;
    public BoolData boolSave;
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        timboCollider=timbo.GetComponent<Collider2D>();
        player=GameObject.Find("player");
        if(boolSave.itemList[1])
        {
            Destroy(timbo);
            Destroy(rock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Player")
        {
            
            timboCollider.enabled=false;
            boolSave.itemList[1]=true;
            Invoke(nameof(fallDown),0.5f);
            Invoke(nameof(destoryTimbo),1.5f);
            
        }
    }

    void fallDown()
    {
        player.GetComponent<Rigidbody2D>().gravityScale=1;
    }

    void destoryTimbo ()
    {
        Destroy(timbo);
    }
}
