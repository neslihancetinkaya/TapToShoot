using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float power = 5f;
    [SerializeField] private float upwardsModifier = 5f;
    
    protected override void ApplyForce()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPosition, explosionRadius, upwardsModifier);
        }
    }
}
