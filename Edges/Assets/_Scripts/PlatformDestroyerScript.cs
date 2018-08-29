using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyerScript : MonoBehaviour {

    GameObject[] PlayerPlatforms;
    GameObject[] Player2Platforms;
    
    // Use this for initialization
    void Start () {
       
        PlayerPlatforms = GameObject.FindGameObjectsWithTag("PlayerPlatform");
        Player2Platforms = GameObject.FindGameObjectsWithTag("Player2Platform");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           for(int i = 0; i < Player2Platforms.Length; i++)
            {
                Player2Platforms[i].SetActive(false);
            }
        }
        else if(collision.tag == "Player2")
        {
            for (int i = 0; i < PlayerPlatforms.Length; i++)
            {
                PlayerPlatforms[i].SetActive(false);
            }
        }
    }

}
