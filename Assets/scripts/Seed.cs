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


    void Start()
    {
        
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
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player"&&!bread)
        {
             AddNewItem();
             
             Instantiate(explosionVFXPrefab,transform.position,transform.rotation);
             Destroy(gameObject);
             changeSenes.getSword=true;
             playermove.PlayOrbAudio();  
                                    
        }
    }
}
