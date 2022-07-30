using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGen : MonoBehaviour
{
    // initialize features
    public bool guilty;

    // arbitrary
    private int hat;
    private int hair;
    private int facialHair;
    private int outfits;

    // tells
    private int face;
    private int decorum;
    private int item;
    private int speech;

    //arrays
    public GameObject[] hatObjects;
    public GameObject[] hairObjects;
    public GameObject[] facialHairObjects;
    public GameObject[] outfitsObjects;

    public GameObject[] faceObjects;
    public GameObject[] decorumObjects;
    public GameObject[] itemObjects;
    public GameObject[] speechObjects;

    // TELL CALCULATION
    // guilty, neutral, innocent
    // each shall carry a number from 1 (guilty) to 3 (innocent)
    private int faceGuilt;
    private int decorumGuilt;
    private int itemGuilt;
    private int speechGuilt;

    // list for tell selection
    private List<int> tellSelect = new List<int>();

    private int tellChosen;

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
            headSprite.color = new Color(1, 0, 0, 1); // dev resource

            // 2 guilty tells (1), 1 neutral (2), and 1 innocent (3)
            // () face () decorum () item () speech
            tellSelect.Add(1);
            tellSelect.Add(1);
            tellSelect.Add(2);
            tellSelect.Add(3);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose face tell
            tellChosen = Random.Range(0, tellSelect.Count);
            faceGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Face guilt is " + faceGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose decorum tell
            tellChosen = Random.Range(0, tellSelect.Count);
            decorumGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Decorum guilt is " + decorumGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose item tell
            tellChosen = Random.Range(0, tellSelect.Count);
            itemGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Item guilt is " + itemGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose speech tell
            tellChosen = Random.Range(0, tellSelect.Count);
            speechGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Speech guilt is " + speechGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");
        }
        else
        {
            headSprite.color = new Color(0, 0, 1, 1); // dev resource

            // 1 guilty tell (1), 1 neutral (2), and 2 innocent (3)
            // () face () decorum () item () speech
            tellSelect.Add(1);
            tellSelect.Add(2);
            tellSelect.Add(3);
            tellSelect.Add(3);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose face tell
            tellChosen = Random.Range(0, tellSelect.Count);
            faceGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Face guilt is " + faceGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose decorum tell
            tellChosen = Random.Range(0, tellSelect.Count);
            decorumGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Decorum guilt is " + decorumGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose item tell
            tellChosen = Random.Range(0, tellSelect.Count);
            itemGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Item guilt is " + itemGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");

            // choose speech tell
            tellChosen = Random.Range(0, tellSelect.Count);
            speechGuilt = tellSelect[tellChosen];
            tellSelect.RemoveAt(tellChosen);
            Debug.Log("Speech guilt is " + speechGuilt);

            foreach (var slot in tellSelect)
            {
                Debug.Log(slot.ToString());
            }
            Debug.Log("");
        }
        Debug.Log("I am: " + guilty.ToString()); // dev resource

        // --- arbitrary appearance --- //
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
            newObject.transform.parent = gameObject.transform;
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
            newObject.transform.parent = gameObject.transform;
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
            newObject.transform.parent = gameObject.transform;
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
            newObject.transform.parent = gameObject.transform;
        }

        // --- tells --- //
        ///// FACE [TELL] /////
        if (faceGuilt == 1) {
            face = 0;
        }
        else if (faceGuilt == 2) {
            face = 1;
        }
        else if (faceGuilt == 3) {
            face = 2;
        }
        //face = Random.Range(0, 3);
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
           newObject.transform.parent = gameObject.transform;
        }
        
        ///// DECORUM [TELL] /////
        if (decorumGuilt == 1) {
            decorum = 0;
        }
        else if (decorumGuilt == 2) {
            decorum = Random.Range(1, 6);
        }
        else if (decorumGuilt == 3) {
            decorum = 6;
        }
        //decorum = Random.Range(0, 7);
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
            // we skip to case 6 to allow the neutral range to incorporate the NULL option
            case 6:
                newObject = Instantiate(decorumObjects[4], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -2.5f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            newObject.transform.parent = gameObject.transform;
            // 4 & 5 are no decorum
        }

        ///// ITEM [TELL] /////
        if (itemGuilt == 1) {
            item = Random.Range(0, 2);
        }
        else if (itemGuilt == 2) {
            item = Random.Range(2, 5);
        }
        else if (itemGuilt == 3) {
            item = 5;
        }
        //item = Random.Range(0, 6);
        switch (item)
        {
            case 0:
                GameObject newObject = Instantiate(itemObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(itemObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(itemObjects[2], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 3:
                newObject = Instantiate(itemObjects[3], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 5:
                newObject = Instantiate(itemObjects[4], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            newObject.transform.parent = gameObject.transform;
        }

        ///// SPEECH [TELL] /////
        if (speechGuilt == 1) {
            speech = Random.Range(0, 5);
        }
        else if (speechGuilt == 2) {
            speech = Random.Range(5, 10);
        }
        else if (speechGuilt == 3) {
            speech = Random.Range(10, 15);
        }
        //speech = Random.Range(0, 15);
        switch (speech)
        {
            case 0:
                GameObject newObject = Instantiate(speechObjects[0], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 1:
                newObject = Instantiate(speechObjects[1], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 2:
                newObject = Instantiate(speechObjects[2], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 3:
                newObject = Instantiate(speechObjects[3], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 4:
                newObject = Instantiate(speechObjects[4], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 5:
                newObject = Instantiate(speechObjects[5], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 6:
                newObject = Instantiate(speechObjects[6], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 7:
                newObject = Instantiate(speechObjects[7], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 8:
                newObject = Instantiate(speechObjects[8], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 9:
                newObject = Instantiate(speechObjects[9], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 10:
                newObject = Instantiate(speechObjects[10], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 11:
                newObject = Instantiate(speechObjects[11], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 12:
                newObject = Instantiate(speechObjects[12], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 13:
                newObject = Instantiate(speechObjects[13], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            case 14:
                newObject = Instantiate(speechObjects[14], new Vector3(gameManager.daSpot.x, gameManager.daSpot.y, -3f), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                break;
            newObject.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {


        // End of round effects
        if (gameManager.resultsTrigger == true)
        {
            Destroy(this.gameObject);
        }

        // generate face animations and speech bubbles (emergent tells)
    }
}
