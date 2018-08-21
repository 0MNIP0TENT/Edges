using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {
    // increase the ball mass
    Rigidbody2D playerRb;
    Rigidbody2D player2Rb;

    GameObject player;
    GameObject player2;
    SpriteRenderer spriteRenderer;

    BallScript ballScript;

    string[] powerUps = { "FasterBallVelocity","GreaterBallMass" };
    string randomPowerUp = "";
    
    float ballSpeedMultiplier = 1.1f;
    private float ballMassMultiplier = 1.1f;

    private void OnEnable()
    {
        randomPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(randomPowerUp == "GreaterBallMass")
        { 
            spriteRenderer.color = Color.magenta;
        }
        Debug.Log("now your playing with power " + randomPowerUp);
    }

    // Use this for initialization
    void Start () {
 
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        

        playerRb = player.GetComponent<Rigidbody2D>();
        player2Rb = player2.GetComponent<Rigidbody2D>(); 
        
    }
    
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "Player" && randomPowerUp == "FasterBallVelocity")
        {
            SoundManagerScript.PlaySound("PowerUp");
            BallScript.nSpeed *= ballSpeedMultiplier;
            BallScript.pSpeed *= ballSpeedMultiplier;
            Debug.Log(BallScript.nSpeed);
            Debug.Log("gots it");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "FasterBallVelocity")
        {
            SoundManagerScript.PlaySound("PowerUp");
            BallScript2.nSpeed *= ballSpeedMultiplier;
            BallScript2.pSpeed *= ballSpeedMultiplier;
            Debug.Log(BallScript2.nSpeed);
            Debug.Log("gots it");
            gameObject.SetActive(false);
        }
        if (collision.tag == "Player" && randomPowerUp == "GreaterBallMass")
        {
            SoundManagerScript.PlaySound("PowerUp");

            BallScript.mass *= ballMassMultiplier;
            
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "GreaterBallMass")
        {
            SoundManagerScript.PlaySound("PowerUp");

            BallScript2.mass *= ballMassMultiplier;
           
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
