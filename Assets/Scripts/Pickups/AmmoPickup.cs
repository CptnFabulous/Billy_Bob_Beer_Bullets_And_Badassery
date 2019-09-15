using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{
    
    public override void ReplenishItem(GameObject character)
    {
        //base.ReplenishItem();
        WeaponHandler wh = character.GetComponent<WeaponHandler>(); // uses generic terms for reference in case we want NPCs and enemies to be able to take this pickup
        Gun g = wh.rightHandGun;

        if (g != null && g.roundsInMagazine < g.magazineCapacity)
        {
            int missingAmmo = g.magazineCapacity - g.roundsInMagazine; // Checks how much ammo the character picking up the ammo pickup is missing
            if (missingAmmo < amountRestored) // If the pickup restores more than what the player currently has
            {
                g.roundsInMagazine = g.magazineCapacity; // Set to max capacity
                amountRestored -= missingAmmo; // Subtract only the necessary health from amountRestored
            }
            else
            {
                g.roundsInMagazine += amountRestored; // Completely consume pickup
                amountRestored = 0;
            }

            if (amountRestored <= 0 || consumeAll == true) // If there is no more value in pickup, or the pickup is set to be entirely consumed regardless
            {
                Destroy(gameObject); // Destroy gameobject
            }
        }


    }
}
