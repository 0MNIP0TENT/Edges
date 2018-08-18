using System;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class Restarter : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player") 
            {
                SoundManagerScript.PlaySound("Fall");
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                Timer.timeLeft = 3;
            }
            
        }
    }

