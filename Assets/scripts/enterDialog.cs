            
using UnityEngine;

public class enterDialog : MonoBehaviour
{
    public GameObject Dialog;
    public dataSave saveData;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Player")
        {
            AddNewPosition(other);
            Dialog.SetActive(true);
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            Dialog.SetActive(false);
        }
    }
    public void AddNewPosition(Collider2D other)
    {

        if(!saveData.taglist.Contains(other.tag))
        {
            saveData.itemList.Add(other.gameObject.transform.position);
            saveData.taglist.Add(other.tag);
        }
        
    }
}
