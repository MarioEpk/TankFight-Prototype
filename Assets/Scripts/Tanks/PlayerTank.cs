using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    [SerializeField]
    private float movementX;
    [SerializeField]
    private float movementY;
    private Vector3 facingDirection;
    [SerializeField]
    private float speed = 5f;
    private ProjectilePoolingScript poolingScript;
    [SerializeField]
    private bool isFiring = false;
    
    
    private void Start()
    {
        poolingScript = gameObject.GetComponent<ProjectilePoolingScript>();
        facingDirection = new Vector3(0, 0, 0);
        fireDelay = 0.25f;
    }


    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        SetRotationBasedOnMovement();

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
        if (!isFiring || fireElapsedTime < fireDelay) return;
            poolingScript.ActivateProjectile();
            fireElapsedTime = 0f;
    }


    private void Move() 
    {
        transform.Translate(movementX * speed * Time.deltaTime, movementY * speed * Time.deltaTime, 0);
        
    }

    private void SetRotationBasedOnMovement()
    {
        facingDirection.z = movementX;
    }
}

