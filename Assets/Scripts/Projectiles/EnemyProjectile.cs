using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this class overrides method DestroyOnCollision(Collider2D collision), to make sure the projectile does not destroy the shotting tank itself
public class EnemyProjectile : ProjectileScript
{
    
    private const string objectName = "Enemy";

    // Start is called before the first frame update
    protected override void DestroyOnCollision(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Destructible")) return;
        Debug.Log(collision.gameObject.name);
        CheckAndDestroy(collision);
    }

    private void CheckAndDestroy(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(objectName)) return;

        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyOnCollision(collision);
    }

}
