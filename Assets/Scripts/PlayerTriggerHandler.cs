using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider t)
    {
        Pickup p = t.GetComponent<Pickup>(); // Detects ammo pickup
        if (p != null)
        {
            p.ReplenishItem(gameObject);
        }




    }
}
