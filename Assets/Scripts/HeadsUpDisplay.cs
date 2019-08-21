using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (PlayerHealth))]

public class HeadsUpDisplay : MonoBehaviour
{
    public Color normalColour;
    public Color criticalColour;

    [Header("Health")]
    public Text healthCounter;

    [Header("Weapon")]
    public Text ammoCounter;
    public Gun equippedWeapon;



    PlayerHealth ph;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    private void Awake()
    {
        ph = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = (equippedWeapon.roundsInMagazine + "/" + equippedWeapon.magazineCapacity);
        healthCounter.text = (ph.currentHealth + "/" + ph.maxHealth);
        if (ph.currentHealth <= ph.maxHealth / 100 * ph.criticalPercentage)
        {
            healthCounter.color = criticalColour;
        }
        else
        {
            healthCounter.color = normalColour;
        }

    }
}
