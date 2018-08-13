using System.Collections;
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

    float move;
    bool grounded = false;
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

            isThrowing = Input.GetButtonDown("Fire2");

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
                Throw();
            }
        }
    }

    public void FixedUpdate()
    {
        if (Timer.timeLeft <= 0)
        {
            move = Input.GetAxis("Horizontal2");
            Move();
        }
    }
    private void Move()
    {
        if (grounded && jump)
        {
            rb.AddForce(transform.up * jumpForce);
            Debug.Log("Jump2");
        }
        // new velocity inherits from old so gravity will pull down 
        // player when moving.  

        Vector2 velocity = (transform.right * move) * maxSpeed * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
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
        if (collision.gameObject.tag != "Ball")
        {
            grounded = true;
            jump = false;
            Debug.Log("grounded");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ball")
        {
            grounded = false;
            Debug.Log("not grounded");
        }
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

