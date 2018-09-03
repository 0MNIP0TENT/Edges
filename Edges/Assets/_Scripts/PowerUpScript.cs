using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpScript : MonoBehaviour {
    
    GameObject player;
    GameObject player2;
    SpriteRenderer spriteRenderer;
    PlayerController playerController;
    Player2Controller player2Controller;

    BallScript ballScript;

    string[] powerUps = { "FasterBallVelocity","GreaterBallMass","JumpHigher","MoveFaster","Shield","AutoFire" };
    string randomPowerUp = "";
    
    //upgrade multipliers
    float ballSpeedMultiplier = 1.25f;
    float ballMassMultiplier = 1.25f;
    float jumpMultiplier = 1.25f;
    float moveMultiplier = 1.25f;

    private void OnEnable()
    {
        randomPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (randomPowerUp == "FasterBallVelocity")
        {
            spriteRenderer.color = Color.green;
        }
        else if(randomPowerUp == "GreaterBallMass")
        { 
            spriteRenderer.color = Color.magenta;
        }
        else if(randomPowerUp == "JumpHigher")
        {
            spriteRenderer.color = Color.cyan;
        }
        else if (randomPowerUp == "MoveFaster")
        {
            spriteRenderer.color = Color.grey;
        }
        else if(randomPowerUp == "Shield")
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (randomPowerUp == "AutoFire")
        {
            spriteRenderer.color = Color.black;
        }
        Debug.Log("now your playing with power " + randomPowerUp);
    }

    // Use this for initialization
    void Start () {
 
       // player = GameObject.FindGameObjectWithTag("Player");
       // player2 = GameObject.FindGameObjectWithTag("Player2");

        playerController = PlayerController.Instance();
        player2Controller = Player2Controller.Instance();
        // playerRb = player.GetComponent<Rigidbody2D>();
        // player2Rb = player2.GetComponent<Rigidbody2D>(); 

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
            Debug.Log("faster ball speed");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "FasterBallVelocity")
        {
            SoundManagerScript.PlaySound("PowerUp");
            BallScript2.nSpeed *= ballSpeedMultiplier;
            BallScript2.pSpeed *= ballSpeedMultiplier;
            Debug.Log(BallScript2.nSpeed);
            Debug.Log("faster ball speed");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player" && randomPowerUp == "GreaterBallMass")
        {
            SoundManagerScript.PlaySound("PowerUp");

            BallScript.mass *= ballMassMultiplier;
            Debug.Log("ball mass");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "GreaterBallMass")
        {
            SoundManagerScript.PlaySound("PowerUp");

            BallScript2.mass *= ballMassMultiplier;
            Debug.Log("ball mass");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player" && randomPowerUp == "JumpHigher")
        {
            SoundManagerScript.PlaySound("PowerUp");

            playerController.jumpForce *= jumpMultiplier;
            Debug.Log("JumpHigher");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "JumpHigher")
        {
            SoundManagerScript.PlaySound("PowerUp");

            player2Controller.jumpForce *= jumpMultiplier;
            Debug.Log("JumpHigher");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player" && randomPowerUp == "MoveFaster")
        {
            SoundManagerScript.PlaySound("PowerUp");

            playerController.maxSpeed *= moveMultiplier;
            Debug.Log("MoveFaster");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "MoveFaster")
        {
            SoundManagerScript.PlaySound("PowerUp");

            player2Controller.maxSpeed *= moveMultiplier;
            Debug.Log("MoveFaster");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player" && randomPowerUp == "Shield")
        {
            SoundManagerScript.PlaySound("PowerUp");

            playerController.hasShield = !playerController.hasShield;
            Debug.Log("Shield");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "Shield")
        {
            SoundManagerScript.PlaySound("PowerUp");

            player2Controller.hasShield = !player2Controller.hasShield;
            Debug.Log("shield");
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Player" && randomPowerUp == "AutoFire")
        {
            gameObject.SetActive(false);
            SoundManagerScript.PlaySound("PowerUp");

            playerController.autoFire = !playerController.autoFire;
            Debug.Log("auto fire");
            
            Debug.Log(playerController.autoFire);
        }
        else if (collision.tag == "Player2" && randomPowerUp == "AutoFire")
        {
            SoundManagerScript.PlaySound("PowerUp");

            player2Controller.autoFire = !player2Controller.autoFire;
            Debug.Log("auto fire");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
