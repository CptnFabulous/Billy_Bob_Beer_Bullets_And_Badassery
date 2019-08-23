using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public int amountRestored;
    public bool consumeAll;
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public virtual void ReplenishItem(GameObject player)
    {
        // Do code for replenishing item based on pickup type
    }
}
