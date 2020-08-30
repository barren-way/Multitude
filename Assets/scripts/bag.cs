using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bags;
    public Inventory myBag;
    public bool bagOpen=true;
    public Item thisItem;
    public GameObject explosionVFXPrefab;
    void Start()
    {
        bags=GameObject.Find("bag");
    }

    // Update is called once per frame
    void Update()
    {
        openBag();
    }

    void openBag()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            bagOpen=!bagOpen;
            bags.SetActive(bagOpen);
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
        if(other.tag=="seed")
        {
            AddNewItem();
             Instantiate(explosionVFXPrefab,transform.position,transform.rotation);
             Destroy(other.gameObject);
             changeSenes.getSword=true;
             playermove.PlayOrbAudio();
        }
    }
}
