using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public GameObject seeds;
    public BoolData boolSave;
    public GameObject sword;
    public GameObject frame;
    private Item onItem;
    public GameObject player;
    public Position breadPosition;

    void Awake()
    {
        if(instance !=null)
            Destroy(this);
        instance = this;
        RefreshItem();
        player=GameObject.Find("player");
    }
    void Update()
    {
        checkSword();
        checkOnObject();
        
    }
    private void onEnable()
    {
        RefreshItem();
    }
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        //复制操作
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem=item;
        newItem.slotImage.sprite=item.itemImage;
    }
    public static void RefreshItem()
    {
        for(int i =0;i<instance.slotGrid.transform.childCount;i++)
        {
            if(instance.slotGrid.transform.childCount==0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);

        }
        for(int i =0;i<instance.myBag.itemList.Count;i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
    public void checkSword()
    {
        boolSave.itemList[0]=false;
        for(int i =0;i<myBag.itemList.Count;i++)
        {
            if(myBag.itemList[i].itemName=="sword")
            {
                Destroy(sword);
                boolSave.itemList[0]=true;
            }
        }
    }
    
    public void checkOnObject()
    {
        onItem=myBag.itemList[frame.GetComponent<Frame>().num];
        if(onItem.itemName=="seed")
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                myBag.itemList.Remove(onItem);
                RefreshItem();
                GameObject newItem = Instantiate(seeds,instance.player.transform.position,Quaternion.identity);
                newItem.GetComponent<Seed>().bread=true;
                newItem.transform.position=new Vector3(newItem.transform.position.x,newItem.transform.position.y-0.8f,newItem.transform.position.z);
            }
        }
    }

}
