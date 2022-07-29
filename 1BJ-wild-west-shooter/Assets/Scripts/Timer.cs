using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    
    private float timeValue;
    public float timeElapsed;

    // fetch game manager
    public GameObject manager;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //timerText = GameObject.FindWithTag("timerUI");
        
        manager = GameObject.FindWithTag("manager");
        gameManager = manager.GetComponent<GameManager>();

        // Start at 5 seconds Round 1, and less thereafter
        timeValue = 6 - (1 * ((manager.GetComponent<GameManager>().roundNumber-1)/10));
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            timeElapsed += Time.deltaTime;
            //Debug.Log(timeElapsed);
        }
        else 
        {
            manager.GetComponent<GameManager>().roundOver = true;
        }

        // display time remaining
        //timerText.text = timeValue.ToString();
    }
}
