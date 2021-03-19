using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

// there is still bug that not all projectiles are being destroyed after timeElapsed. Possible fix, set outOfBounds for X, and Y and deactivate projectiles outOfBounds
public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float timeElapsed = 4f;
    

    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        // projectile movement
        transform.Translate(0, speed * Time.deltaTime, 0);
        StartCoroutine(Inactivate());
    }


    IEnumerator Inactivate()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeElapsed);
            gameObject.SetActive(false);
        }
    }


    // Destroy object on trigger, if the object is tagged "Destructible"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeactivateDestructibles(collision);
    }


    protected virtual void DeactivateDestructibles(Collider2D collision)
    {
        // add extra condition to make sure the shooting tank does not destroy itself
        if (!collision.gameObject.CompareTag("Destructible")) return;

        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
