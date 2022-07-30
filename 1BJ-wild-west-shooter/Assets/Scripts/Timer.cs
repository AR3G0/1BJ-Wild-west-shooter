using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeElapsed;

    private float timerDisplay;

    // fetch game manager
    public GameObject manager;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {   
        manager = GameObject.FindWithTag("manager");
        gameManager = manager.GetComponent<GameManager>();

        // Start at 5 seconds Round 1, and less thereafter
        gameManager.timeRemaining = 6 - (1 * ((manager.GetComponent<GameManager>().roundNumber-1)/10));
        gameManager.roundTime = gameManager.timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {

        if ((gameManager.timeRemaining > 0) && (gameManager.roundOver == false))
        {
            gameManager.timeRemaining -= Time.deltaTime;
            timeElapsed += Time.deltaTime;
            //Debug.Log(timeElapsed);
        }
        else 
        {
            manager.GetComponent<GameManager>().roundOver = true;
        }

        timerDisplay = ((Mathf.Round(gameManager.timeRemaining * 100.0f)) / 100.0f);
        if (timerDisplay < 0)
        {
            timerDisplay = 0.0f * 10.0f;
        }
        timerText.text = timerDisplay.ToString();


        // display time remaining
        //timerText.text = gameManager.timeRemaining.ToString();
    }
}
