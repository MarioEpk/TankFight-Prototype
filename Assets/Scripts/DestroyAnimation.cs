using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attach this to any tank, or any object that you wish to have a the prefab animation to be played on collision with a projectile
public class TankExplosion : MonoBehaviour
{
    [SerializeField]
    private Animation destroyAnimation;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<ProjectileScript>()) return;


        // here code that spawns / plays the explosion animation
        //Instantiate(destroyAnimation, transform.position, Quaternion.identity);
       
        
    }

}
