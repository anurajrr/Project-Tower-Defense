using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{   
    [SerializeField] Transform cannonPrefab;
    [SerializeField] Transform targetPrefab;

    void Start()
    {
        targetPrefab = FindObjectOfType<EnemyMovement>().transform;
    }

    void Update()
    {
        Aim();
    }

    public void Aim()
    {
        Vector3 targetPosition = targetPrefab.position;
        Vector3 directionToTarget = targetPosition - cannonPrefab.position;

        // Calculate the rotation only along the y-axis
        float yRotation = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;

        // Apply the rotation to the cannon only along the y-axis
        cannonPrefab.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
