using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraMove : MonoBehaviour
{

    public GameObject player;

    void Awake()
    {
        player=GameObject.Find("player");
        gameObject.GetComponent<CinemachineVirtualCamera>().m_Follow=player.transform;
    }

}
