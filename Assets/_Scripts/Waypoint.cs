using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{   
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        DisplayWaypoint();
    }


    public void DisplayWaypoint()
    {
        foreach (Waypoint waypoint in path)
        {
            Debug.Log(waypoint);
        }
    }


}
