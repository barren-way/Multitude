using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mybag;
    public bool bagOpen=true;
    void Start()
    {
        
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
            mybag.SetActive(bagOpen);
        }
    }
}
