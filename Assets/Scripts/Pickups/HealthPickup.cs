using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public override void ReplenishItem(GameObject character)
    {
        //base.ReplenishItem();
        Health h = character.GetComponent<Health>(); // uses generic health for reference in case we want NPCs and enemies to be able to take this pickup
        if (h != null && h.currentHealth < h.maxHealth)
        {
            int missingHealth = h.maxHealth - h.currentHealth; // Checks how much health the character picking up the health pickup is missing
            if (missingHealth < amountRestored) // If the pickup restores more than what the player currently has
            {
                h.currentHealth = h.maxHealth; // Set to max health
                amountRestored -= missingHealth; // Subtract only the necessary health from amountRestored
            }
            else
            {
                h.currentHealth += amountRestored; // Completely consume pickup
                amountRestored = 0;
            }
            
            if (amountRestored <= 0 || consumeAll == true) // If there is no more value in pickup, or the pickup is set to be entirely consumed regardless
            {
                Destroy(gameObject); // Destroy gameobject
            }
        }

    }
}
