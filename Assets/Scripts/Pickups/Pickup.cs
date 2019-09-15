using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public int amountRestored;
    public bool consumeAll;

    public virtual void ReplenishItem(GameObject player)
    {
        // Do code for replenishing item based on pickup type
    }
}
