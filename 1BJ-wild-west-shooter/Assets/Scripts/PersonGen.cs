using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGen : MonoBehaviour
{
    // initialize features
    public bool guilty;

    private int hat;
    private int hair;
    private int clothes;
    private int decorum;
    private int item;

    // fetch the game manager
    private GameObject manager;
    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = manager.GetComponent<GameManager>();

        guilty = (Random.value > 0.5f);

        hat = Random.Range(1, 6);
        hair = Random.Range(1, 6);
        clothes = Random.Range(1, 6);
        decorum = Random.Range(1, 6);
        item = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        // display correct apparel per above


        // generate face animations and text bubbles (emergent tells)
    }
}
