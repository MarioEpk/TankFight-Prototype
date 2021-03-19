using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this class overrides method DestroyOnCollision(Collider2D collision), to make sure the projectile does not destroy the shotting tank itself
public class PlayerProjectile : ProjectileScript 
{ 

    private const string objectName = "Player";

    // Start is called before the first frame update
    protected override void DeactivateDestructibles(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Destructible")) return;

        CheckAndDestroy(collision);
    }

    private void CheckAndDestroy(Collider2D collision)
    {
        if (collision.gameObject.name == objectName) return;

        Destroy(collision.gameObject);
        gameObject.SetActive(false);
        UpdateScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeactivateDestructibles(collision);
    }

    private void UpdateScore()
    {
        GameManager.score += 1;
    }

}
