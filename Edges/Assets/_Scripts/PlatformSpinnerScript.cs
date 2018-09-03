using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpinnerScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            GameObject[] player2Platforms = GameObject.FindGameObjectsWithTag("Player2Platform");
            for (int i = 0; i < player2Platforms.Length; i++)
            {
                player2Platforms[i].GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
        else if (collision.tag == "Player2")
        {
            GameObject[] playerPlatforms = GameObject.FindGameObjectsWithTag("PlayerPlatform");
            for (int i = 0; i < playerPlatforms.Length; i++)
            {
                playerPlatforms[i].GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
    }

}
