﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Controller : MonoBehaviour
{

    public static Player2Controller player2Controller;
    Rigidbody2D rb;
    public float maxSpeed = 500;
    public int up = 0;
    public int jumpForce = 500;
    public bool facingRight = false;

    int canJump = 0;
    float move;
    bool jump = false;
    bool isThrowing;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timeLeft <= 0)
        {

            jump = Input.GetButtonDown("Jump2");
            move = Input.GetAxis("Horizontal2");
            isThrowing = Input.GetButtonDown("Fire2");

            if (jump && canJump < 2)
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

            if (isThrowing)
            {
                SoundManagerScript.PlaySound("Throw");
                Throw();
            }
        }
    }

    public void FixedUpdate()
    {
        if (Timer.timeLeft <= 0)
        {
            Move();
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
            Debug.Log("Jump");
    }

    public void flip(float move)
    {
        if (move < 0)
        {
            facingRight = false;
        }
        else if (move > 0)
        {
            facingRight = true;
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
            GameObject obj = ObjectPooler2.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            obj.SetActive(true);
        }
        else
        {
            GameObject obj = ObjectPooler2.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            obj.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // stops from being able to jump after hit by a ball
        if (collision.gameObject.tag != "Ball")
        {
            if(rb.velocity.y == 0)
                canJump = 0;
           
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
       
    }

    public static Player2Controller Instance()
    {
        if (!player2Controller)
            player2Controller = FindObjectOfType(typeof(Player2Controller)) as Player2Controller;
        if (!player2Controller)
            Debug.LogError("There needs to be one active playerController in the scene");
        return player2Controller;
    }

}

