using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] protected float force;

    protected override void Awake()
    {
        base.Awake();
        time = 0f;
    }

    protected override void ApplyForce()
    {
        rigidbody.AddForceAtPosition(Vector3.forward * force, transform.position);
    }
}
