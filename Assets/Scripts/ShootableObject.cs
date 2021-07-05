using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    private Boolean isHit = false;
    protected virtual void Awake()
    {
        gameObject.tag = "Shootable";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Projectile") && !isHit)
        {
            Director.hitCount += 1;
            isHit = true;
        }
    }
}
