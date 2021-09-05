using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject player;
    private Vector3 targetPos;
    
/// <summary>
/// this makes camera follow the player
/// </summary>
    void Update()
    {
        targetPos.z = player.transform.position.z;
        targetPos.x = player.transform.position.x;
        targetPos.y = 40f;

        mainCam.transform.position = targetPos;
        
    }
}
