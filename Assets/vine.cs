using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vine : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    void afterGrow()
    {
        anim.SetBool("grow",false);
    }
}
