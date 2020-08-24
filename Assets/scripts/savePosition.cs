using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePosition : MonoBehaviour
{
    // Start is called before the first frame update
    public dataSave saveData;
    void OnTriggerEnter2D(Collider2D other)
    {
        AddNewPosition(other);
    }
    public void AddNewPosition(Collider2D other)
    {

        for(int i=0;i<saveData.taglist.Count;i++)
        {
            if(saveData.taglist[i]=="Player")
            {
                saveData.itemList[i]=other.gameObject.transform.position;

            }
            
        }
        
    }
}
