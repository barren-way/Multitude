using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource DeathAudio;
    
    protected virtual void Start()
    {
        anim=GetComponent<Animator>();
        DeathAudio = GetComponent<AudioSource>();
    }
    public void death()
    {
        
        Destroy(gameObject);
    }

    public void jumpOn()
    {
        
        anim.SetTrigger("death");
        DeathAudio.Play();
        
    }


}
