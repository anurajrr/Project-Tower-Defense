using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range (0,5)] float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(FollowPath());    
    }


     IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition =  transform.position;
            Vector3 endPosition =waypoint.transform.position;
            float timeTravel = 0f;
            transform.LookAt(endPosition);
            while(timeTravel < 1f)
            {
                timeTravel += Time.deltaTime * enemySpeed;
            transform.position = Vector3.Lerp(startPosition,endPosition,timeTravel);
            yield return new WaitForEndOfFrame();
            }
        }
    }
}
