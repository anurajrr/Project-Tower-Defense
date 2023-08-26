using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour {

    public Tower twr;             // Reference to the tower script
    public bool lockE;            // Flag to lock onto an enemy
    public GameObject curTarget;  // Current target being tracked by the tower trigger

    // Called when an object enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyBug") && !lockE) // Check if the entering object is an enemy and not locked onto
        {   
            twr.target = other.gameObject.transform; // Set the tower's target to the enemy
            curTarget = other.gameObject; // Store the current target
            lockE = true; // Lock onto the enemy
        }
    }

    void Update()
    {
        // Check if the current target exists
        if (curTarget)
        {
            if (curTarget.CompareTag("Dead")) // Check if the current target has the tag "Dead" (indicating it's defeated)
            {
                lockE = false; // Unlock the enemy targeting
                twr.target = null; // Clear the tower's target
            }
        }

        // If the current target is missing
        if (!curTarget) 
        {
            lockE = false; // Unlock the enemy targeting            
        }
    }

    // Called when an object exits the trigger collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemyBug") && other.gameObject == curTarget) // Check if the exiting object is the current target
        {
            lockE = false; // Unlock the enemy targeting
            twr.target = null; // Clear the tower's target
        }
    }
}
