using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Rigidbody rigidbody;
    
    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        ApplyForce();
        Destroy(this.gameObject,2f);
    }

    protected virtual void ApplyForce() {}
}
