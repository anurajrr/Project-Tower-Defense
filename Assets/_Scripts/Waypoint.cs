using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{   
    [SerializeField] bool isPlacable;
    [SerializeField] GameObject cannonTower;

    
    private void OnMouseDown() 
    {   if(isPlacable)
        {
            Instantiate(cannonTower,transform.position,transform.rotation);
            isPlacable =false;
        }
    }
}
