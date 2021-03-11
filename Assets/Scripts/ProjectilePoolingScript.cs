﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    private int pooledAmount = 35;
    private List<GameObject> projectiles;
    private float projectileYOffset = 3.5f;


    // Pool projectiles on game start
    void Start()
    {
        projectiles = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(projectilePrefab);
            obj.SetActive(false);
            projectiles.Add(obj);
        }
    }
    // Fire a bullet on method call


    public void ActivateProjectile()
    {
        for(int i = 0; i < projectiles.Count; i++)
        {
            if (!projectiles[i].activeInHierarchy)
            {
                projectiles[i].transform.position = transform.position + new Vector3(0, projectileYOffset, 0);
                projectiles[i].transform.rotation = transform.rotation;
                projectiles[i].SetActive(true);
                break;
            }
        }
    }
}