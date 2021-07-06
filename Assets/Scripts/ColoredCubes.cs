using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColoredCubes : ShootableObject
{
    private Rigidbody rigidbody;
    [SerializeField] private GameObject coloredCube;

    protected override void Awake()
    {
        base.Awake();

        rigidbody = coloredCube.GetComponent<Rigidbody>();
        rigidbody.GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (Director.enabled)
        {
            changeColor();
        }
    }

    private void changeColor()
    {
        if (Director.shootClick)
        {
            rigidbody.GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV();
            Director.shootClick = false;
        }
    }
}
