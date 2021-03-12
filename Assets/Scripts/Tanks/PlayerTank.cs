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
    private float speed = 500f;
    private ProjectilePoolingScript poolingScript;
    [SerializeField]
    private bool isFiring = false;
    private Rigidbody2D playerRb;
    [SerializeField]
    


    private bool isFacingLeft = false;
    private bool isFacingRight = false;
    private bool isFacingUp = false;
    private bool isFacingDown = false;




    private void Start()
    {
        
        poolingScript = gameObject.GetComponent<ProjectilePoolingScript>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        fireDelay = 0.25f;
    }


    void Update()
    {
        
        GetPlayerInput();
    }


    void FixedUpdate()
    {
        // reseting rotation direction, so we can correctly rotate to where we need to go
        
        MovePlayer();
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


    private void MovePlayer()
    {
        // tuto metodu upravit, rozdelit do ifov aj velocity a malo by to fungovat. Potom restrictnut diagonal movement a mame hotovy player movement
        playerRb.velocity = new Vector2(CalculateSpeed(movementX), CalculateSpeed(movementY));
        if (movementX > 0)
            
        {
            movementY = 0;
            FaceRight();
        }
        if (movementX < 0)
        {
            movementY = 0;
            FaceLeft();
            
        }
        if (movementY < 0)
        {
            movementX = 0;
            FaceDown();
        }

        if (movementY > 0)
        {
            movementX = 0;
            FaceUp();
        }

    }

    private void FaceUp()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void FaceDown()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    private void FaceLeft()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void FaceRight()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }


    private void GetPlayerInput()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFiring = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isFiring = false;
        }
        
    }

    private float CalculateSpeed(float movement)
    {
        return movement * Time.deltaTime * speed;
    }

}
    



