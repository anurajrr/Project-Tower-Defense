using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float Waittime;
    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("Started");
        StartCoroutine(FollowPath());    
        Debug.Log("Finished");
    }


     IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            // Debug.Log(waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(Waittime);
        }
    }
}
