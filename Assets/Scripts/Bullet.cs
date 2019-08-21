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

    public float projectileLifetime;
    float timerLifetime;


    // Update is called once per frame
    void Update()
    {
        bulletRay.origin = transform.position;
        bulletRay.direction = transform.forward;

        float raycastLength = velocity * Time.deltaTime;
        if (Physics.SphereCast(bulletRay, diameter / 2, out bulletHit, raycastLength, rayDetection))
        {
            OnHit();
        }
        else
        {
            MoveBullet();
        }

        timerLifetime += Time.deltaTime;
        if (timerLifetime >= projectileLifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnHit()
    {
        
        // do stuff like deal damage, cosmetic effects
        Destroy(gameObject);
    }

    void MoveBullet()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }
}
