using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : MonoBehaviour
{
    // Start is called before the first frame update
    public bool grow;
    private Animator anim;
    public GameObject useDialog;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grow && Input.GetButton("Pull"))
        {
            anim.SetBool("grow",true); 
            useDialog.SetActive(false); 
        }
    }
}
