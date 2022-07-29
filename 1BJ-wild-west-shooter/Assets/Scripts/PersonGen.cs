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
    SpriteRenderer sprite;

    // game manager
    public GameObject manager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // fetch game manager
        manager = GameObject.FindWithTag("manager");
        gameManager = manager.GetComponent<GameManager>();

        sprite = GetComponent<SpriteRenderer>();

        guilty = (Random.value > 0.5f);
        if (guilty)
        {
            sprite.color = new Color(1, 0, 0, 1);
        }
        else
        {
            sprite.color = new Color(0, 0, 1, 1);
        }
        Debug.Log("I am: " + guilty.ToString());

        hat = Random.Range(1, 4);
        hair = Random.Range(1, 6);
        clothes = Random.Range(1, 6);
        decorum = Random.Range(1, 6);
        item = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        // display correct apparel per above
        switch (hat)
        {
            case 1:
                //Sprite.Create();
                break;
            case 2:
                ;
                break;
            case 3:
                ;
                break;

        }

        // End of round effects
        if (gameManager.resultsTrigger == true)
        {

        }

        // generate face animations and speech bubbles (emergent tells)
    }
}
