using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    Rigidbody2D rb;
    private float ballSpeed;
    private GameObject player;
    private PlayerController playerController;
    private float direction;


    private void Awake()
    {
        playerController = PlayerController.Instance();
        rb = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    // OnEnable cant rely on start because it called after and only once
    void Start () {


        
    }
    private void OnEnable()
    {
        if (!playerController.facingRight)
            ballSpeed = -40;
        else
            ballSpeed = 40;

        rb.velocity = new Vector2(ballSpeed, 1);

        Invoke("SetInActive", 5);
    }

    private void FixedUpdate()
    {


    }
    private void SetInActive()
    {
        gameObject.SetActive(false);
    }
}
