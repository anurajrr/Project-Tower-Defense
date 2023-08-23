using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        WaypointPos();        
    }


    public void WaypointPos()
    {
        foreach (Waypoint waypoint in path)
        {
            Debug.Log(waypoint);
        }
    }
}
