using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attach this class on a object you want spawn projectiles on - dont forget to attach a prefab projectile of your choice to this scripts projectilePrefab
public class ProjectilePoolingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    private int pooledAmount = 20;
    private List<GameObject> projectiles;
    


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
                projectiles[i].transform.position = transform.position;
                projectiles[i].transform.rotation = transform.rotation;
                projectiles[i].SetActive(true);
                break;
            }
        }
    }
}