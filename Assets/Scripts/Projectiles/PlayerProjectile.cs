using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this class overrides method DestroyOnCollision(Collider2D collision), to make sure the projectile does not destroy the shotting tank itself
public class PlayerProjectile : ProjectileScript 
{
    private int scoreForEachEnemy = 1;
    private const string objectName = "Player";

    // Start is called before the first frame update
    protected override void DeactivateDestructibles(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Destructible")) return;

        CheckAndDestroy(collision);
    }

    private void CheckAndDestroy(Collider2D collision)
    {
        // to not destroy self
        if (collision.gameObject.name == objectName) return;

        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
        
        // adds score if the destroyed object was Enemy
        if (collision.gameObject.name.Contains("Enemy"))
        {
            ScoreManager.UpdateScore(scoreForEachEnemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeactivateDestructibles(collision);
    }


}
