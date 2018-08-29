using System;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class Restarter : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player") 
            {
                LevelManager.player2Points++;
                SoundManagerScript.PlaySound("Fall");
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                Timer.timeLeft = 3;

            BallScript.mass = 35;
            BallScript2.mass = 35;
            BallScript.nSpeed = -40;
            BallScript.pSpeed = 40;
            BallScript2.nSpeed = -40;
            BallScript2.pSpeed = 40;
        }
            else if (other.tag == "Player2")
            {
                LevelManager.playerPoints++;
                SoundManagerScript.PlaySound("Fall");
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                Timer.timeLeft = 3;

            BallScript.mass = 35;
            BallScript2.mass = 35;
            BallScript.nSpeed = -40;
            BallScript.pSpeed = 40;
            BallScript2.nSpeed = -40;
            BallScript2.pSpeed = 40;
            
            
        }
        
    }
    }

