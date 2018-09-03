using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravityScript : MonoBehaviour {
    Rigidbody2D playerRb;
    Rigidbody2D player2Rb;
    private bool NoGravity = false;

    // Use this for initialization
    void Start () {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        player2Rb = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            NoGravity = true;
        }
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        rb.gravityScale = 400;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        NoGravity = false;
    }
}
