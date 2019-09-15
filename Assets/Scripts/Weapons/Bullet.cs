using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet physics stats
    [HideInInspector] public float diameter;
    [HideInInspector] public float velocity;
    Vector3 desiredVelocity;
    Vector3 ballisticDirection;
    Vector3 gravityModifier;

    // Damage stats
    [HideInInspector] public int damage;

    // Visual effect variables
    [HideInInspector] public GameObject impactPrefab;

    // Raycast variables
    Ray bulletRay; // Raycast launched to determine shot direction
    RaycastHit bulletHit; // Point where raycast hits target
    [HideInInspector] public LayerMask rayDetection; // LayerMask ensuring raycast does not hit player's own body
    float raycastLength;

    public float projectileLifetime;
    float timerLifetime;


    // Update is called once per frame
    void Update()
    {
        bulletRay.origin = transform.position;
        bulletRay.direction = transform.forward;

        raycastLength = velocity * Time.deltaTime; // Determines how long the raycast should be
        if (Physics.SphereCast(bulletRay, diameter / 2, out bulletHit, raycastLength, rayDetection)) // Launches raycast, if it hits an object do appropriate hit functions, if not move bullet
        {
            OnHit();
        }
        else
        {
            MoveBullet();
        }

        // Counts up lifetime timer and destroys gameObject if it has been existing for too long, so they do not clutter up the level.
        timerLifetime += Time.deltaTime;
        if (timerLifetime >= projectileLifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnHit()
    {
        Health targetHealth = bulletHit.collider.GetComponent<Health>(); // Checks for health script
        if (targetHealth != null) // If present
        {
            targetHealth.Damage(damage); // Damage object
        }
        // do stuff like deal damage, cosmetic effects
        Destroy(gameObject); // Destroy bullet
    }

    void MoveBullet() // Moves bullet forward the exact distance as the raycast launched previously, to ensure it moves forward at the correct rate and no section of the bullet's flight path is unchecked
    {
        transform.position += transform.forward * raycastLength;
    }
}
