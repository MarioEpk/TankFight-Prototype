using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBase
{

    private ProjectilePoolingScript poolingScript;
    // Start is called before the first frame update
    void Start()
    {
        poolingScript = gameObject.GetComponent<ProjectilePoolingScript>();
        fireDelay = Random.Range(1.0f, 3.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fire();
        fireElapsedTime += Time.deltaTime;
    }

    private void Fire()
    {
        if (fireElapsedTime < fireDelay) return;
        
        poolingScript.ActivateProjectile();
        fireElapsedTime = 0f;
    }
}
