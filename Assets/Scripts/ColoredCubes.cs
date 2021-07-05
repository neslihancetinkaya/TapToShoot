using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredCubes : ShootableObject
{
    protected override void Awake()
    {
        base.Awake();
        renderer.material.SetColor("_Color", Random.ColorHSV());
    }
}
