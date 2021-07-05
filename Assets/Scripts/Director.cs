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
    [SerializeField] private GameObject coloredCube;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject levelCompleted;
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private int maxFPSonEditor;
    [SerializeField] private float range;
    [SerializeField] private float bombSpeed;
    [SerializeField] private float bulletSpeed;
    
    private Rigidbody rigidbody;
    private int maxHit;
    public static int hitCount = 0;
    private Boolean enabled = true;
    
    private void Awake()
    {
        levelCompleted.SetActive(false);
        
        #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxFPSonEditor;
        #endif

        maxHit = column * row;
        
        CreateWall(row, column);
        
        rigidbody = coloredCube.GetComponent<Rigidbody>();
        rigidbody.GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV();
    }
    
    void Update()
    {
        if (enabled)
        {
            Shoot();
        }

        if (hitCount == maxHit)
        {
            enabled = false;
            levelCompleted.SetActive(true);
        }
    }
    
    private void Shoot()
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
                    rigidbody.GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV();
                    GameObject bullet_ = Instantiate(bullet, Camera.main.transform.position, Quaternion.AngleAxis(90, Vector3.left));
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
                    rigidbody.GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV();
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
                Instantiate(coloredCube, new Vector3(i * range * coloredCube.transform.localScale.x, j * range * coloredCube.transform.localScale.y, 0), Quaternion.identity);
            }
        }
    }
}
