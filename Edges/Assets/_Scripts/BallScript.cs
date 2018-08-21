using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public static BallScript ballScript;
    float ballSpeed;
    public static float nSpeed = -40;
    public static float pSpeed = 40;
    private GameObject player;
    private PlayerController playerController;
    private float direction;
    private Rigidbody2D rb;
    public static float mass = 35f;

    private void Awake()
    {
        playerController = PlayerController.Instance();
        rb = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    // OnEnable cant rely on start because it called after and only once
    void Start () {

        rb.mass = mass;
        
    }
    private void OnEnable()
    {
        if (!playerController.facingRight)
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

    public static BallScript Instance()
    {
        if (!ballScript)
            ballScript = FindObjectOfType(typeof(BallScript)) as BallScript;
        if (!ballScript)
            Debug.LogError("There needs to be one active BallScript in the scene");
        return ballScript;
    }
}
