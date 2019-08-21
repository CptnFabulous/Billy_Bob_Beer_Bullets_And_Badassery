using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadsUpDisplay : MonoBehaviour
{
    public Text healthCounter;
    public Text ammoCounter;
    public Gun equippedWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = equippedWeapon.roundsInMagazine.ToString();
    }
}
