using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory myBag;
    public GameObject explosionVFXPrefab;

    public BoolData boolSave;
    public Item thisItem;
    public bool bread=false;
    public Collider2D pickColl;
    public Collider2D breadColl;
    public bool grow;
    public GameObject timbo;
    public Animator anim;



    void Start()
    {
        Transform[] trans=GetComponentsInChildren<Transform>();
        timbo=trans[2].gameObject;
        anim=timbo.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkSeed();
    }
    public void checkSeed()
    {
        boolSave.itemList[0]=false;
        for(int i =0;i<myBag.itemList.Count;i++)
        {
            /*if(myBag.itemList[i].itemName=="sword")
            {
                Destroy(gameObject);
                boolSave.itemList[0]=true;
            }*/
        }
        if(bread)
        {
            pickColl.enabled=false;
            breadColl.enabled=true;
        }
    }
    public void AddNewItem()
    {

        if(!myBag.itemList.Contains(thisItem))
        {
            myBag.itemList.Add(thisItem);
        }
        
        //InventoryManager.CreateNewItem(thisItem);
        InventoryManager.RefreshItem();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"&&bread)
        {

            anim.SetBool("grow",true);                                  
        }
    }
}
