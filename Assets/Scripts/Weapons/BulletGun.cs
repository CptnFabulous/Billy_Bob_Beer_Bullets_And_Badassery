using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : Gun
{
    [Header("Projectile")]
    public Bullet projectile; // Projectile to launch
    public Transform weaponMuzzle; // Location to launch projectile from
    public float projectileDiameter = 0.1f; // Width of projectile for hit detection
    public float projectileVelocity = 100; // Speed at which projectile moves

    [Header("Cosmetic")]
    //public ParticleSystem shellEjection;
    public ParticleSystem muzzleFlash; // Muzzle flash animation
    // public GameObject shellPrefab;


    public override void Shoot()
    {
        base.Shoot();

        // Play appropriate firing animations
        muzzleFlash.Play();
        //shellEjection.Play();

    }

    public override void LaunchProjectile()
    {
        base.LaunchProjectile();

        // Instantiate object with RaycastBullet for conventional kinetic projectiles e.g. bullets.
        GameObject bullet = Instantiate(projectile.gameObject, weaponMuzzle.transform.position, Quaternion.LookRotation(target - weaponMuzzle.transform.position, Vector3.up));
        // Sets bullet stats to match those specified in this class
        projectile.diameter = projectileDiameter;
        projectile.velocity = projectileVelocity;
        projectile.damage = damage;
        projectile.rayDetection = rayDetection;
    }
}