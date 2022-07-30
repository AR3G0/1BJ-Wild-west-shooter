using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeElapsed;

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
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.timeRemaining > 0)
        {
            gameManager.timeRemaining -= Time.deltaTime;
            timeElapsed += Time.deltaTime;
            //Debug.Log(timeElapsed);
        }
        else 
        {
            manager.GetComponent<GameManager>().roundOver = true;
        }

        timerText.text = gameManager.timeRemaining.ToString("2F");


        // display time remaining
        //timerText.text = gameManager.timeRemaining.ToString();
    }
}
