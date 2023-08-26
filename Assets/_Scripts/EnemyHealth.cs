using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [SerializeField] int maxhealth = 5;
    [SerializeField] int currenthealth;

    private void Start() 
    {
        currenthealth = maxhealth;    
    }
    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currenthealth--;
        if(currenthealth <= 0)
        {
            Debug.Log("ENemy Dead");
            Destroy(gameObject);
        }
    }
}
