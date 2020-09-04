using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bags;
    public Inventory myBag;
    public bool bagOpen=true;

    public GameObject explosionVFXPrefab;
    public bool onSeed,onMachine;
    public GameObject thisObject;
    public Item machine,seed;
    void Start()
    {
        bags=GameObject.Find("bag");
    }

    // Update is called once per frame
    void Update()
    {
        openBag();
        pickObject();
    }

    void openBag()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            bagOpen=!bagOpen;
            bags.SetActive(bagOpen);
        }
    }
    public void AddNewItem(Item thisItem)
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
        if(other.tag=="seed")
        {
            onSeed=true;
            thisObject=other.gameObject;
        }
        if(other.tag=="machine")
        {
            onMachine=true;
            thisObject=other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="seed")
        {
            onSeed=false;
        }
    }

    public void pickObject()
    {
        if(Input.GetButton("Pull"))
        {
            if(onSeed)
            {
                AddNewItem(seed);
                Instantiate(explosionVFXPrefab,transform.position,transform.rotation);
                Destroy(thisObject);
                playermove.PlayOrbAudio();
            }
            if(onMachine)
            {
                AddNewItem(machine);
                
            }
            
        }
    }
}
