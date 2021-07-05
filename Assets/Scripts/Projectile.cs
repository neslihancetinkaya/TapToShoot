using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Rigidbody rigidbody;
    protected float time;
    
    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameObject.tag = "Projectile";
    }
    
    private void OnCollisionEnter(Collision other)
    {
        ApplyForce();
        Destroy(this.gameObject,time);
    }

    protected virtual void ApplyForce() {}
}
