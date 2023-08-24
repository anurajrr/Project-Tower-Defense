using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour {

    public int CastleHp = 20; // Current health of the castle

    // Function to apply damage to the castle
    public void Dmg_2(int DMG_2count)
    {
        CastleHp -= DMG_2count; // Reduce castle's health by the damage count
    }

    private void Update()
    {
        // Check if the castle's health has reached or fallen below zero
        if (CastleHp <= 0)
        {
            gameObject.tag = "Castle_Destroyed"; // Change the tag to "Castle_Destroyed" to indicate the castle is destroyed
            Destroy(gameObject); // Destroy the game object

            // Note: Changing the tag could be used to inform other systems, like TowerTrigger, that the castle is destroyed
            // and actions related to that can be taken.
        }
    }
}
