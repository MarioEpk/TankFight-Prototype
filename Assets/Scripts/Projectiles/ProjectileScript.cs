using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;

    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        StartCoroutine(Inactivate());
    }

    
    IEnumerator Inactivate()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }


    // Destroy object on trigger, if the object is tagged "Destructible"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyOnCollision(collision);
    }

    protected virtual void DestroyOnCollision(Collider2D collision)
    {
        // add extra condition to make sure the shooting tank does not destroy itself
        if (!collision.gameObject.CompareTag("Destructible")) return;

        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    
}
