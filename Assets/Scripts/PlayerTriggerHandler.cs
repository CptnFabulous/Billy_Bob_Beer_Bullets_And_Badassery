using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider t) // If trigger is entered
    {
        Pickup p = t.GetComponent<Pickup>(); // Checks for pickup
        if (p != null) // If pickup found
        {
            p.ReplenishItem(gameObject); // Pick up pickup
        }
    }
}
// I realised later that I could've just put the OnTriggerEnter() code on the pickup itself, but whatever