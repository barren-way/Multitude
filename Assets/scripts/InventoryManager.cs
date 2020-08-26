using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public BoolData boolSave;
    public GameObject sword;

    void Awake()
    {
        if(instance !=null)
            Destroy(this);
        instance = this;
        RefreshItem();
    }
    void Update()
    {
        checkSword();
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

}
