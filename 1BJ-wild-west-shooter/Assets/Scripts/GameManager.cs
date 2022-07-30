using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int roundNumber;
    public bool roundOver = false;
    public bool resultsTrigger = false;
    public bool nextSceneInvoked = false;

    public int score = 0;
    public int highScore = 0;

    public bool playerLost = false;

    // The timer remaning in a round for the timer script
    public float roundTime;
    public float timeElapsed;
    public float timeRemaining;

    // fetch the person generator
    public GameObject person;
    public PersonGen personGen;
    public Vector3 daSpot;

    // player's gun
    public GameObject playerGunObject1;
    public GameObject playerGunObject2;

    // round status
    private bool newSceneFlag = false;
    private bool playerShot = false;

    private static GameManager managerInstance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        // No duplicate managers
        if (managerInstance == null) {
            managerInstance = this;
        } 
        else {
            Object.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // The Player Button 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Shoot
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Gameplay"))
            {
                GameObject playerGun1 = Instantiate(playerGunObject1, new Vector3(1f, -.5f, -6f), Quaternion.identity);
                playerGun1.transform.localScale = new Vector3(0.75f, 0.75f, 1);
                Invoke("PlayerGunAnimation1", 0.1f);
                playerShot = true;
                roundOver = true;
            }
            // Press Play
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("MainMenu")) 
            {
                playerShot = false;
                roundOver = false;
                newSceneFlag = false;
                SceneManager.LoadScene("Gameplay");
            }
            // Continue
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("GameOver")) 
            {
                score = 0;
                playerShot = false;
                roundOver = false;
                newSceneFlag = false;
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (newSceneFlag == false && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
        {
            // Create round components
            GameObject newPerson = Instantiate(person, new Vector3(daSpot.x, daSpot.y, -1f), Quaternion.identity);
            personGen = newPerson.GetComponent<PersonGen>();
            newSceneFlag = true;
        }

        // trigger lasts only one frame: for activating results elsewhere
        if (resultsTrigger == true)
        {
            resultsTrigger = false;
        }

        // End of round
        if ((roundOver == true) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay")))
        {
            // determine outcome
            // LOSE: didn't shoot baddie
            if ((playerShot == false) && (personGen.guilty == true))
            {
                playerLost = true;
                // animation of player being shot
                // sfx: gun shot + evil laugh or crowd gasp
            }
            // LOSE: shot innocent
            else if ((playerShot == true) && (personGen.guilty == false))
            {
                playerLost = true;
                // animation of player shooting them, them going down?
                // sfx: gun shot + crowd gasp
            }

            // WIN: didn't shoot innocent
            else if ((playerShot == false) && (personGen.guilty == false))
            {
                // sfx: person leaving + "phew"
            }
            // WIN: shot baddie
            else if ((playerShot == true) && (personGen.guilty == true))
            {
                // animation of player shooting them, baddie going down?
                // sfx: gun shot + fanfare
            }

            // wait two seconds for results of player actions
            if ((nextSceneInvoked == false) && (playerLost == false))
            {
                Invoke("NextRound", 2.0f);
                resultsTrigger = true;
                nextSceneInvoked = true;
            }
            else if ((nextSceneInvoked == false) && (playerLost == true))
            {
                Invoke("GameOver", 2.0f);
                resultsTrigger = true;
                nextSceneInvoked = true;
            }
        }

    }
    
    void PlayerGunAnimation1()
    {
        //playerGunObject1.SetActive(false);
        GameObject playerGun2 = Instantiate(playerGunObject2, new Vector3(3f, -.5f, -6f), Quaternion.identity);
        playerGun2.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        Invoke("PlayerGunAnimation2", 0.1f);

    }
    void PlayerGunAnimation2()
    {

    }

    void NextRound()
    {
        roundNumber += 1;
        newSceneFlag = false;
        nextSceneInvoked = false;
        playerShot = false;
        roundOver = false;
        playerLost = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        newSceneFlag = false;
        nextSceneInvoked = false;
        playerShot = false;
        roundOver = false;
        playerLost = false;
        SceneManager.LoadScene("GameOver");
    }

}
