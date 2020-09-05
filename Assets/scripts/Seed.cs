using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject slope;




    void Start()
    {
        Transform[] trans=GetComponentsInChildren<Transform>();
        slope=GameObject.Find("slope");
        timbo=trans[2].gameObject;
        anim=timbo.gameObject.GetComponent<Animator>();
        checkScenes();
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
            timbo.SetActive(true);
        }
        else if(anim.GetBool("grow"))
        {
            timbo.SetActive(false);
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


     void OnTriggerStay2D(Collider2D other)

    {
        if(other.tag == "light"&&bread)
        {

            anim.SetBool("grow",true);                                  
        }
    }
    void checkScenes()
    {
        if(SceneManager.GetActiveScene().buildIndex!=3)
        {
            timbo.GetComponent<Collider2D>().enabled=false;
        }
        else
        {
            if(!slope.GetComponent<slope>().onSlope)
            {
                timbo.GetComponent<Collider2D>().enabled=false;
            }
        }
    }
}
