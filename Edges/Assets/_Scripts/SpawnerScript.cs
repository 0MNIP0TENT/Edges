using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    int randomTime;
    GameObject powerUp;

    // Use this for initialization
    void Start () {
        // stores the random powerup and the random amount of time to spawn
        powerUp = transform.Find("PowerUp").gameObject;
        randomTime = Random.Range(0, 60);
        StartCoroutine("LoseTime");
    }
	
	// Update is called once per frame
	void Update () {
        // coroutine controlls when the powerup is spawned
        if (randomTime <= 0)
        {
            StopCoroutine("LoseTime");
            powerUp.gameObject.SetActive(true);
            randomTime = Random.Range(0, 120);
            StartCoroutine("LoseTime");

        }
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            randomTime--;
        }
    }
}
