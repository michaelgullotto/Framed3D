using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    public GameObject player;
    public GameObject GuardObject;
    public NavMeshAgent Guard;
    private bool randompath = false;
    [SerializeField]private Vector3 randomLoc;
    Rigidbody AIrb;

    private void Start()
    {
        
    }

    /// <summary>
    /// creates floats to calculate distance from player and end of path
    /// if player gets to close will chase player
    /// if player isn't to close will chose random destination
    /// </summary>
    void Update()
    {
        float distance = (player.transform.position - Guard.transform.position).magnitude;
        float pathleft = (Guard.transform.position - randomLoc).magnitude;
        
        // if player gets to close will chase player
        if (distance <= 20f)
        {
            Guard.SetDestination(player.transform.position);
            randompath = false;
        }
       // if player isn't to close will chose random destination
        else if (distance > 20f)
        {
            if (!randompath)
            {
                randomLoc.x = GuardObject.transform.position.x + (Random.Range(-10f, 10f)); 
                randomLoc.z = GuardObject.transform.position.z + (Random.Range(-10f, 10f));
                randomLoc.y = 3f;
                // stops random roll sending ai off map
                if (randomLoc.x > 100)
                {
                    randomLoc.x = 100f;
                }
                if (randomLoc.x < 0)
                {
                    randomLoc.x = 0f;
                }
                if (randomLoc.z > 70)
                {
                    randomLoc.z = 70f;
                }
                if (randomLoc.z < -180)
                {
                    randomLoc.z = -180f;
                }
                // sets the ais destnation
                Guard.SetDestination(randomLoc);
                randompath = true;
            }
            // once ai has path and gets close enough to its target location chose a new path
            else if (randompath)
            {
                if (pathleft < 5f)
                {
                    randompath = false;
                }
            }
        }
    }
   
}
