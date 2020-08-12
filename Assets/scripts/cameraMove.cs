using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraMove : MonoBehaviour
{

    public GameObject player;


    void Start()
    {
        transform.position=new Vector3 (0,0,-10);
        player=GameObject.Find("player");
        gameObject.GetComponent<CinemachineVirtualCamera>().m_Follow=player.transform;
    }

}
