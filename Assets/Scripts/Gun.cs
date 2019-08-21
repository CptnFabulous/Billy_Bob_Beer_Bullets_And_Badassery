using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Joystick input;


    [Header("General Stats")]
    [Tooltip("The amount of damage a weapon deals with a standard attack.")]
    public int damage = 10;

    [Header("Accuracy")]
    [Tooltip("Level of deviation in weapon accuracy from centre of reticle, in degrees.")]
    [Range(0, 180)] public float projectileSpread = 5;
    [Tooltip("Amount of recoil applied per shot.")]
    public float recoil = 10;
    [Tooltip("Speed at which camera returns to starting position.")]
    public float recoilRecovery = 10;
    [Tooltip("Maximum range for the gun's raycast check to determine where to launch projectiles. Decrease this value if the weapon is not meant to hit accurately past a certain point.")]
    public float range = 500;
    [Tooltip("What layers will the raycast check and launched projectiles register?")]
    public LayerMask rayDetection;
    Ray targetRay;
    RaycastHit targetFound;
    [HideInInspector] public Vector3 target;

    [Header("Fire Rate")]
    [Tooltip("Amount of projectiles launched per shot. Set to 1 for regular bullet-shooting weapons, increase for weapons such as shotguns.")]
    [Min(1)] public int projectileCount = 1;
    [Tooltip("Cyclic fire rate, in rounds per minute.")]
    public float roundsPerMinute = 600;
    [Tooltip("Amount of shots that can be fired before needing to re-press the trigger. Set to 1 for semi-automatic, or more for burst-fire weapons. Set to zero to enable full-auto fire.")]
    public int burstCount;
    float fireTimer = 9999999999;
    float shotsInBurst;

    [Header("Ammunition")]
    [Tooltip("How many units of ammunition are consumed per shot.")]
    public int ammoPerShot = 1;
    [Tooltip("Sets weapon's magazine capacity. Set to zero to ignore magazine code, allowing the player to fire continuously without reloading.")]
    [Min(0)] public int magazineCapacity = 30;
    [Tooltip("Amount of ammunition currently in the weapon's magazine.")]
    public int roundsInMagazine = 30;


#if UNITY_EDITOR
    void Reset() { OnValidate(); }
    void OnValidate()
    {
        roundsInMagazine = Mathf.Clamp(roundsInMagazine, 0, magazineCapacity);
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (input.Direction != Vector2.zero && fireTimer >= 60 / roundsPerMinute && (shotsInBurst < burstCount || burstCount <= 0) && roundsInMagazine > 0)
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        for (int i = 0; i < projectileCount; i++) // Shoots an amount of projectiles based on the projectileCount variable.
        {
            LaunchProjectile();
        }
        if (burstCount > 0) // If the weapon fires in bursts
        {
            shotsInBurst += 1; // Adds number to burst count
        }
        roundsInMagazine -= ammoPerShot;
        //ammoSupply.Spend(caliber, ammoPerShot); // Spends appropriate ammunition type
        fireTimer = 0; // Reset fire timer to count up to next shot
        // Cosmetic effects are done in another derived class, for different cosmetic effects.
    }

    public virtual void LaunchProjectile()
    {
        targetRay.origin = transform.position;
        targetRay.direction = Quaternion.Euler(Random.Range(-projectileSpread, projectileSpread), Random.Range(-projectileSpread, projectileSpread), Random.Range(-projectileSpread, projectileSpread)) * transform.forward;
        if (Physics.Raycast(targetRay, out targetFound, range, rayDetection))
        {
            target = targetFound.point;
        }
        else
        {
            target = targetRay.direction * range;
        }
        // Instantiating of projectile is done in another derived class, so different kinds of projectiles can be instantiated
    }
}
