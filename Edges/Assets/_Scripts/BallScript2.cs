﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript2 : MonoBehaviour
{

    Rigidbody2D rb;
    private float ballSpeed;
    private GameObject player;
    private Player2Controller player2Controller;
    private float direction;


    private void Awake()
    {
        player2Controller = Player2Controller.Instance();
        rb = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    // OnEnable cant rely on start because it called after and only once
    void Start()
    {



    }
    private void OnEnable()
    {
        if (!player2Controller.facingRight)
            ballSpeed = -40;
        else
            ballSpeed = 40;

        rb.velocity = new Vector2(ballSpeed, 1);

        Invoke("SetInActive", 5);
        Debug.Log(player2Controller.facingRight);
    }

    private void FixedUpdate()
    {


    }
    private void SetInActive()
    {
        gameObject.SetActive(false);
    }
}
