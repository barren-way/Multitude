using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    static SaveManager instance;
    public dataSave myData;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Vector3 newPosition;


    void Awake()
    {
        if(instance !=null)
            Destroy(this);
        instance = this;
        RefreshItem();
    }
    private void onEnable()
    {
        RefreshItem();
    }
    public static void CreateNewItem(GameObject item)
    {
        instance.newPosition=item.transform.position;
        
    }
    public static void RefreshItem()
    {

    }

}
