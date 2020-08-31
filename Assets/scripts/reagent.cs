using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reagent : MonoBehaviour
{
    public GameObject explosionVFXPrefab;
    public GameObject useDialog;
    public GameObject Monkey;
    public int Catalyzer;
    public Text CatalyzerNum;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Pull"))
        {
            anim.SetBool("light",true); 
            //useDialog.SetActive(false); 
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
             Instantiate(explosionVFXPrefab,transform.position,transform.rotation);
             playermove.PlayOrbAudio();  
             Catalyzer += 1;
             CatalyzerNum.text = Catalyzer.ToString(); 
             useDialog.SetActive(true);  
             Monkey.GetComponent<monkey>().grow = true;
             Destroy(gameObject);                     
        }
    }
}
