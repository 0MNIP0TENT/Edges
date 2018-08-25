using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int playerPoints = 0, player2Points = 0;
    private static int playerWins = 0, player2Wins = 0;
    public Text playerScore;
    public Text player2Score;
    public Text playerWinsText;
    public Text player2WinsText;
    // static int so i can easily track the levels
    static int levelNumber = 1;

    // Use this for initialization
    void Awake () {
     //   DontDestroyOnLoad(this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
        // load level two
        if(playerPoints >= 3 && levelNumber == 1)
        {
            playerWins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        else if(player2Points >= 3 && levelNumber == 1)
        {
            player2Wins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }

        // load level 3
        else if (playerPoints >= 3 && levelNumber == 2)
        {
            playerWins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
        else if (player2Points >= 3 && levelNumber == 2)
        {
            player2Wins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }

        // load level 4
        else if (playerPoints >= 3 && levelNumber == 3)
        {
            playerWins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level4", LoadSceneMode.Single);
        }
        else if (player2Points >= 3 && levelNumber == 3)
        {
            player2Wins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level4", LoadSceneMode.Single);
        }
        // load level 5
        else if (playerPoints >= 3 && levelNumber == 4)
        {
            playerWins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level5", LoadSceneMode.Single);
        }
        else if (player2Points >= 3 && levelNumber == 4)
        {
            player2Wins++;
            playerPoints = 0;
            player2Points = 0;
            levelNumber++;
            SceneManager.LoadScene("Level5", LoadSceneMode.Single);
        }

        playerScore.text = playerPoints.ToString();
        player2Score.text = player2Points.ToString();

        playerWinsText.text = playerWins.ToString();
        player2WinsText.text = player2Wins.ToString();
    }

   
}
