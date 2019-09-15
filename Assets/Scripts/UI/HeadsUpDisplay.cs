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
        ammoCounter.text = (wh.rightHandGun.roundsInMagazine + "/" + wh.rightHandGun.magazineCapacity); // Displays remaining ammo on counter
        healthCounter.text = (ph.currentHealth + "/" + ph.maxHealth); // Displays remaining health on counter
        if (ph.currentHealth <= ph.maxHealth / 100 * ph.criticalPercentage) // Checks status of health and displays appropriate colour
        {
            healthCounter.color = criticalColour;
        }
        else
        {
            healthCounter.color = normalColour;
        }

        string objectiveText = ""; // Prepares objective message
        if (oh.remainingAliens == 1) // Displays number of aliens remaining to defeat, two variants to display appropriate grammar based on number of aliens
        {
            objectiveText += (oh.remainingAliens + " ALIEN REMAINS");
        }
        else
        {
            objectiveText += (oh.remainingAliens + " ALIENS REMAIN");
        }
        float aa = GameObject.FindGameObjectsWithTag(oh.enemyTag).Length;
        if (aa > 0) // Checks how many aliens are currently in the level, if so, adds text to objective message showing number of aliens currently attacking the player
        {
            objectiveText += (", " + aa + " ATTACKING");
        }
        objectiveList.text = objectiveText; // Displays objective message
        

    }
}
