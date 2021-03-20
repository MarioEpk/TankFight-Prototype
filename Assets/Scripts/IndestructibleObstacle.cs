using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Deactivates all lasers
public class IndestructibleObstacle : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Laser")) return;
        collision.gameObject.SetActive(false);
    }
}
