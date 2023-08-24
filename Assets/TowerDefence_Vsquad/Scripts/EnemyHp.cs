using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour {

    public int EnemyHP = 30;  // Current health of the enemy

    // Function to apply damage to the enemy
    public void Dmg(int DMGcount)
    {
        EnemyHP -= DMGcount;  // Reduce enemy's health by the damage count
    }

    private void Update()
    {        
        // Check if the enemy's health has reached or fallen below zero
        if (EnemyHP <= 0)
        {
            gameObject.tag = "Dead"; // Change the tag to "Dead" to indicate the enemy is defeated
            
            // The purpose of changing the tag might be to inform other parts of the game
            // (like the TowerTrigger) that the enemy is defeated and actions related to that can be taken.
        }
    }  
}
