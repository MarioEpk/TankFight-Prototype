using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    [SerializeField]
    private float movementX;
    private float movementY;
    [SerializeField]
    private float speed = 5f;
    private ProjectilePoolingScript poolingScript;
    [SerializeField]
    private bool isFiring = false;
    private float fireDelay = 0.25f;
    private float fireElapsedTime = 0f;


    private void Start()
    {
        poolingScript = gameObject.GetComponent<ProjectilePoolingScript>();
    }


    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFiring = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            isFiring = false;
        }
    }


    void FixedUpdate()
    {
        Move();
        Fire();
        fireElapsedTime += Time.deltaTime;
    }


    // Custom helper methods
    private void Fire()
    {
        if (!isFiring) return;
        if(fireElapsedTime >= fireDelay)
        {
            poolingScript.ActivateProjectile();
            fireElapsedTime = 0f;
        }
    }


    private void Move() 
    {
        transform.Translate(movementX * speed * Time.deltaTime, movementY * speed * Time.deltaTime, 0);
    }
}

