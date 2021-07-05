using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public Rigidbody rigidbody;
    protected Renderer renderer;
    protected virtual void Awake()
    {
        gameObject.tag = "Shootable";
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }
}
