using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    //public bool tallyPoints = false;
    
    // game manager
    public GameObject manager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // fetch game manager
        manager = GameObject.FindWithTag("manager");
        gameManager = manager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // display text
        scoreText.text = gameManager.score.ToString();
        highScoreText.text = "HIGHSCORE: " + gameManager.highScore.ToString();

        // tally points (at end of round)
        if (gameManager.resultsTrigger == true)
        {
            // GUILTY: More points the faster you shoot them
            if (gameManager.personGen.guilty == true)
            {
                // 1000 points if you fire immediately
                // less points if it takes you 4 seconds
                //gameManager.score += (1000 - (((int)((gameManager.timer.timeElapsed)*10.0f) * 10) * 1));
            }
/*
*/
            // INNOCENT: Static points since you have to wait it out
            else
            {
                // 500 points no matter what
                gameManager.score += 500;
            }
        }

        if (gameManager.score > gameManager.highScore)
        {
            gameManager.highScore = gameManager.score;
        }
    }
}
