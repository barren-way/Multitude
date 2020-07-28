            
using UnityEngine;

public class enterDialog : MonoBehaviour
{
    public GameObject Dialog;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Player")
        {
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
}
