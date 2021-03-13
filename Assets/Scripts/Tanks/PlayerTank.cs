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
    private float speed = 10f;
    private ProjectilePoolingScript poolingScript;
    [SerializeField]
    private bool isFiring = false;
    private Rigidbody2D playerRb;
    

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

    // MovePlayer() restricts diagonal movement, and also make player object rotate to the direction it's curently moving
    private void MovePlayer()
    {

        if (movementX > 0)
        {    
            playerRb.MovePosition(playerRb.position + new Vector2(CalculateSpeed(movementX), 0));
            FaceRight();
        }
        if (movementX < 0)
        {
            
            playerRb.MovePosition(playerRb.position + new Vector2(CalculateSpeed(movementX), 0));
            FaceLeft();   
        }
        if (movementY < 0)
        {
            
            playerRb.MovePosition(playerRb.position + new Vector2(0, CalculateSpeed(movementY)));
            FaceDown();
        }

        if (movementY > 0)
        {
            
            playerRb.MovePosition(playerRb.position + new Vector2(0, CalculateSpeed(movementY)));
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
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        
      
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
    



