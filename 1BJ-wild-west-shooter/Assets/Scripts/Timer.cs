using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeValue;

    private GameObject manager;
    private GameManager GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = manager.GetComponent<GameManager>();
        // Start at 5 seconds Round 1, and less thereafter
        timeValue = 6 - (1 * ((manager.GetComponent<GameManager>().roundNumber-1)/10));
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else 
        {
            manager.GetComponent<GameManager>().roundOver = true;
        }
    }
}
