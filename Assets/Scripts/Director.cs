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
    [SerializeField] private GameObject shootableObject;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject levelCompleted;
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private int maxFPSonEditor;
    [SerializeField] private float range;
    [SerializeField] private float bombSpeed;
    [SerializeField] private float bulletSpeed;
    private int maxHit;
    public static int hitCount = 0;
    public static Boolean enabled = true;
    public static Boolean shootClick = false;
    
    private void Awake()
    {
        levelCompleted.SetActive(false);
        
        #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxFPSonEditor;
        #endif

        maxHit = column * row;
        
        CreateWall(row, column);
    }
    
    void Update()
    {
        if (enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Shoot(bullet, bulletSpeed, ray);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Shoot(bomb, bombSpeed, ray);
            }
        }

        if (hitCount == maxHit)
        {
            enabled = false;
            levelCompleted.SetActive(true);
        }
    }
    
    private void Shoot(GameObject projectile, float projectileSpeed, Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit2))
        {
            string colliderTag = hit2.collider.tag;
            if (colliderTag == "Shootable")
            {
                shootClick = true;
                GameObject projectile_ = Instantiate(projectile, Camera.main.transform.position, Quaternion.identity);
                projectile_.GetComponent<Rigidbody>().AddForce(ray.direction * projectileSpeed);
            }
        }
        
    }

    void CreateWall(int row, int column)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Instantiate(shootableObject, new Vector3(i * range * shootableObject.transform.localScale.x, j * range * shootableObject.transform.localScale.y, 0), Quaternion.identity);
            }
        }
    }
}
