using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGen : MonoBehaviour
{
    // initialize features
    public bool guilty;

    private int hat;
    private int hair;
    private int face;
    private int facialHair;
    private int outfits;
    private int decorum;
    private int item;

    public GameObject[] hatObjects;
    public GameObject[] hairObjects;
    public GameObject[] faceObjects;
    public GameObject[] facialHairObjects;
    public GameObject[] outfitsObjects;
    public GameObject[] decorumObjects;
    public GameObject[] itemObjects;

    // initialie the child and head object so we can change their color
    //private GameObject head;
    private GameObject body;

    // game manager
    public GameObject manager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // fetch game manager
        manager = GameObject.FindWithTag("manager");
        gameManager = manager.GetComponent<GameManager>();

        //fetch the head and body object so we can change their sprite render
        Transform head = transform.Find("Head");
        SpriteRenderer headSprite = head.GetComponent<SpriteRenderer>();

        guilty = (Random.value > 0.5f);
        if (guilty)
        {
            headSprite.color = new Color(1, 0, 0, 1);
        }
        else
        {
            headSprite.color = new Color(0, 0, 1, 1);
        }
        Debug.Log("I am: " + guilty.ToString());

        ///// HATS /////
        hat = Random.Range(0, 4);
        // display correct apparel per above
        switch (hat)
        {
            case 0:
                GameObject newObject = Instantiate(hatObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -4f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(hatObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -4f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            // 2 and three is no hat
        }

        ///// HAIR /////
        hair = Random.Range(0, 6);
        switch (hair)
        {
            case 0:
                GameObject newObject = Instantiate(hairObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(hairObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(hairObjects[2], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 3:
                newObject = Instantiate(hairObjects[3], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 4:
                newObject = Instantiate(hairObjects[4], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
                // five is a bald dude
        }

        ///// FACE [GUILTY] /////
        face = Random.Range(0, 3);
        switch (face)
        {
            case 0:
                GameObject newObject = Instantiate(faceObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(faceObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(faceObjects[2], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
        }

        ///// FACIAL HAIR /////
        facialHair = Random.Range(0, 4);
        switch (facialHair)
        {
            case 0:
                GameObject newObject = Instantiate(facialHairObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(facialHairObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            // 2 and three are stashless
        }

        ///// OUTFITS /////
        outfits = Random.Range(0, 5);
        switch (outfits) 
        {
            case 0:
                GameObject newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(outfitsObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(outfitsObjects[2], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 3:
                newObject = Instantiate(outfitsObjects[3], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 4:
                newObject = Instantiate(outfitsObjects[4], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
        }

        ///// DECORATIONS /////
        decorum = Random.Range(0, 7);
        switch (decorum)
        {
            case 0:
                GameObject newObject = Instantiate(decorumObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2.5f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(decorumObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2.5f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(decorumObjects[2], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2.5f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 3:
                newObject = Instantiate(decorumObjects[3], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2.5f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 4:
                newObject = Instantiate(decorumObjects[3], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2.5f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            // five and six are no decorum
        }

        ///// ITEM [GUILTY] /////
        item = Random.Range(0, 6);
        switch (outfits)
        {
            case 0:
                GameObject newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 3:
                newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 4:
                newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 5:
                newObject = Instantiate(outfitsObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {


        // End of round effects
        if (gameManager.resultsTrigger == true)
        {

        }

        // generate face animations and speech bubbles (emergent tells)
    }
}
