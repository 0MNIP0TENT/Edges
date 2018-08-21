using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript2 : MonoBehaviour
{
    public static BallScript2 ballScript2;
    public static float nSpeed = -40;
    public static float pSpeed = 40;
    public static float mass = 35f;

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
        rb.mass = mass;
    }
    private void OnEnable()
    {
        if (!player2Controller.facingRight)
        {
            ballSpeed = nSpeed;
        }
        else
            ballSpeed = pSpeed;

        rb.mass = mass;

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
    public static BallScript2 Instance()
    {
        if (!ballScript2)
            ballScript2 = FindObjectOfType(typeof(BallScript2)) as BallScript2;
        if (!ballScript2)
            Debug.LogError("There needs to be one active BallScript2 in the scene");
        return ballScript2;
    }
}

