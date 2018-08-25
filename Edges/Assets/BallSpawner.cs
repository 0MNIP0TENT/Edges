using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    float randomVX, randomVY;
    int randomNumber;

    private void OnEnable()
    {
        randomVX = Random.Range(-25f, 25f);
        randomVY = Random.Range(-25f, 25f);
        
    }

    // Use this for initialization
    void Start () {

        
    }
	
	
	void FixedUpdate () {
        randomNumber = Random.Range(0, 100);
        randomVX = Random.Range(0f, 35f);
        randomVY = Random.Range(0f, 35f);
        if (randomNumber == 1)
        {
            GameObject obj = ObjectPooler2.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = new Vector2(transform.position.x, transform.position.y);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(randomVX, randomVY);
            obj.SetActive(true);
        }
        else if (randomNumber == 3)
        {
            GameObject obj = ObjectPuller.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = new Vector2(transform.position.x, transform.position.y);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(randomVX, randomVY);
            obj.SetActive(true);
        }
    }
}
