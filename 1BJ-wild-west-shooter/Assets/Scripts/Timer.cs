using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeValue;

    public GameObject manager;
    public GameManager GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = manager.GetComponent<GameManager>();
        //timeValue = 6 - (1 * ((roundNumber-1)/10));
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        //else (
            //roundOver = true;
        //)
    }
}
