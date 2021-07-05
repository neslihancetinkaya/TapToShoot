using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Random = UnityEngine.Random;

public class Director : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private float range;
    [SerializeField] private float bombSpeed;
    [SerializeField] private float bulletSpeed;
    
    private void Awake()
    {
        CreateWall(row, column);
    }
    
    void Update()
    {
        CreateProjectile();
    }
/*
    void ChangeColor()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, 5f);
        
        foreach (Collider hit in colliders)
        {
            
            Renderer rer = hit.GetComponent<Renderer>();
            rer.material.SetColor("_Color", Random.ColorHSV());
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            
        }
    }*/

    private void CreateProjectile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                string colliderTag = hit.collider.tag;
                if (colliderTag == "Shootable")
                {
                    //rer.material.SetColor("_Color", Random.ColorHSV());
                    GameObject bullet_ = Instantiate(bullet, Camera.main.transform.position, Quaternion.identity);
                    bullet_.GetComponent<Rigidbody>().AddForce(ray.direction * bulletSpeed);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                string colliderTag = hit.collider.tag;
                if (colliderTag == "Shootable")
                {
                    //Renderer rer = cubes.GetComponent<Renderer>();
                    //rer.material.SetColor("_Color", Random.ColorHSV());
                    GameObject bomb_ = Instantiate(bomb, Camera.main.transform.position, Quaternion.identity);
                    bomb_.GetComponent<Rigidbody>().AddForce(ray.direction * bombSpeed);
                }
            }
        }
        
    }

    void CreateWall(int row, int column)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Instantiate(cube, new Vector3(i * range, j * range, 0), Quaternion.identity);
            }
        }
    }
}
