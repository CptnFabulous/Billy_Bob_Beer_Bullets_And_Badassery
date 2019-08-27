using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{




    public override void Die()
    {
        // do stuff like death animation, death screen etc.
        GetComponent<SimplePlayerController>().enabled = false;
        WeaponHandler wh = GetComponent<WeaponHandler>();
        wh.rightHandGun.enabled = false;
        wh.enabled = false;
        GetComponent<HeadsUpDisplay>().enabled = false;
        GetComponent<PauseMenu>().enabled = false;
        GetComponent<PlayerTriggerHandler>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
