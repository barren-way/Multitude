using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clue : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject information;
    public bool showDialog=false;
    public bool InformationOn=false;
    public bool dialogDestory=false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showInformation();
        
    }
    
    void showInformation()
    {
        if(showDialog&&Input.GetKeyDown(KeyCode.F))
        {
            if(!InformationOn)
            {
                Destroy(Dialog);
                dialogDestory=true;
                information.SetActive(true);
                InformationOn=true;
            }
            else
            {
                information.SetActive(false);
                InformationOn=false;
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Player")
        {
            showDialog=true;
            Dialog.SetActive(true);
        }      
    }


    void OnTriggerExit2D(Collider2D collider)
    {
        
        if(collider.tag=="Player")
        {
            if(!dialogDestory)
            {
                Dialog.SetActive(false);
            }
            showDialog=false;
            information.SetActive(false);
            InformationOn=false;
        }
    }
}
