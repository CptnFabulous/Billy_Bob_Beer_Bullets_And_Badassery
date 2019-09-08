using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (PlayerHealth))]
[RequireComponent(typeof (WeaponHandler))]

public class HeadsUpDisplay : MonoBehaviour
{
    public Color normalColour;
    public Color criticalColour;

    [Header("Health")]
    public Text healthCounter;
    PlayerHealth ph;

    [Header("Weapon")]
    public Text ammoCounter;
    WeaponHandler wh;

    [Header("Objectives")]
    public Text objectiveList;
    ObjectiveHandler oh;



    

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    private void Awake()
    {
        ph = GetComponent<PlayerHealth>();
        wh = GetComponent<WeaponHandler>();
        oh = GetComponent<ObjectiveHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = (wh.rightHandGun.roundsInMagazine + "/" + wh.rightHandGun.magazineCapacity);
        healthCounter.text = (ph.currentHealth + "/" + ph.maxHealth);
        if (ph.currentHealth <= ph.maxHealth / 100 * ph.criticalPercentage)
        {
            healthCounter.color = criticalColour;
        }
        else
        {
            healthCounter.color = normalColour;
        }

        objectiveList.text = (oh.remainingAliens + " ALIENS REMAIN");

    }
}
