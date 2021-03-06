﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public static PlayerController playerController;
    Rigidbody2D rb;
    Transform shield;

    public float maxSpeed = 500f;
    public int up = 0;
    public float jumpForce = 500f;
    public bool facingRight = true;
    public bool hasShield = false;
    public bool autoFire = false;

    bool isThrowingAuto;
    bool block = false;
    int canJump = 0;
    float move;
    bool jump = true;
    bool isThrowing;

    private void OnEnable()
    {
        shield = transform.Find("Shield");
    }

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.timeLeft <= 0)
        { 
           jump = Input.GetButtonDown("Jump");
           move = Input.GetAxis("Horizontal");
           isThrowing = Input.GetButtonDown("Fire1");
           isThrowingAuto = Input.GetButton("Fire1");
           block = Input.GetButton("Block1");

          if(jump && canJump < 2 )
          {
                SoundManagerScript.PlaySound("Jump");
                Jump();
          }

           if (move > 0)
           {
              flip(move);
           }

           else if (move < 0)
           {
               flip(move);
           }

           if (isThrowing && !autoFire)
           {
                SoundManagerScript.PlaySound("Throw");
                Throw();
           }
            
            if (hasShield && block && !isThrowing && !isThrowingAuto)
           {
                shield.gameObject.SetActive(true);
           }
           else
           {
               shield.gameObject.SetActive(false);
           }
        }
    }

    public void FixedUpdate()
    {
        if (Timer.timeLeft <= 0)
        {
            
            Move();
            if (isThrowingAuto && autoFire)
            {
                SoundManagerScript.PlaySound("Throw");
                Throw();
            }
        }
    }
    private void Move()
    {
        
        // new velocity inherits from old so gravity will pull down 
        // player when moving.  

        Vector2 velocity = (transform.right * move) * maxSpeed * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

   private void Jump()
   {
        rb.AddForce(transform.up * jumpForce);
        canJump++;
    }
    public void flip(float move)
    {
        if (move < 0)
        {
            facingRight = false;
            shield.transform.position = new Vector2(transform.position.x - 1.4F, transform.position.y - .8f);
        }
        else if (move > 0)
        {
            facingRight = true;
            shield.transform.position = new Vector2(transform.position.x + 2, transform.position.y - .8f);
        }
    }
    
    private void Throw() 
    {
        SetDirection(facingRight);
    }

    // sets which side of player ball spawns
    public void SetDirection(bool direction)
    {
        if (direction)
        {
            GameObject obj = ObjectPuller.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = new Vector2(transform.position.x + 1.4f, transform.position.y);
            obj.SetActive(true);
        }
        else
        {
            GameObject obj = ObjectPuller.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = new Vector2(transform.position.x - 1.4f, transform.position.y);
            obj.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ball")
        {
            // if (rb.velocity.y == 0)
            canJump = 0;

        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
       
    }

    public static PlayerController Instance()
    {
        if(!playerController)
            playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        if (!playerController)
            Debug.LogError("There needs to be one active playerController in the scene");
        return playerController;
    }
   
}
