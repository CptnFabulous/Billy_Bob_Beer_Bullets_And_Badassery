using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : Gun
{
    [Header("Projectile")]
    public Bullet projectile;
    public Transform weaponMuzzle;
    public float projectileDiameter = 0.1f;
    public float projectileVelocity = 100;

    [Header("Cosmetic")]
    public ParticleSystem shellEjection;
    public ParticleSystem muzzleFlash;
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
        projectile.diameter = projectileDiameter;
        projectile.velocity = projectileVelocity;
        projectile.damage = damage;
        projectile.rayDetection = rayDetection;
    }
}