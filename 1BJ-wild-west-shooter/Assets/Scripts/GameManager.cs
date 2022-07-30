using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int roundNumber;
    public bool roundOver = false;
    public bool resultsTrigger = false;
    public bool nextRoundInvoked = false;

    public int score = 0;
    public int highScore = 0;

    private bool playerLost = false;

    // The timer remaning in a round for the timer script
    public float timeRemaining;

    // fetch the person generator
    public GameObject person;
    public PersonGen personGen;
    public Vector3 daSpot;

    public GameObject playerGun;

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
            DestroyObject(gameObject);
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
            
            Instantiate(playerGun);

            // Shoot
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Gameplay"))
            {
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
            //GameObject newClock = Instantiate(clock);
            GameObject newPerson = Instantiate(person, new Vector3(daSpot.x, daSpot.y, -1f), Quaternion.identity);
            //timer = newClock.GetComponent<Timer>();
            personGen = newPerson.GetComponent<PersonGen>();
            newSceneFlag = true;
        }

        // trigger lasts only one frame: for activating results elsewhere
        if (resultsTrigger == true)
        {
            resultsTrigger = false;
        }

        if ((roundOver == true) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay")))
        {
            // determine outcome
            // LOSE: didn't shoot baddie
            if ((playerShot == false) && (personGen.guilty == true))
            {
                playerLost = true;
                // animation of player being shot
                // then go to lose screen
                // possible lose screen: player's own funeral
                SceneManager.LoadScene("GameOver");
            }
            // LOSE: shot innocent
            else if ((playerShot == true) && (personGen.guilty == false))
            {
                playerLost = true;
                // go to lose screen
                // possible lose screen: player attends their funeral
                SceneManager.LoadScene("GameOver");
            }

            // WIN: didn't shoot innocent
            else if ((playerShot == false) && (personGen.guilty == false))
            {
                // animation or sound effect of innocent being relieved (phew)
                // then next person
            }
            // WIN: shot baddie
            else if ((playerShot == true) && (personGen.guilty == true))
            {
                // animation and sound effect of baddie going down
                // then next person
            }

            // wait two seconds before launching next round
            if ((nextRoundInvoked == false) && (playerLost == false))
            {
                Invoke("NextRound", 2.0f);
                resultsTrigger = true;
                nextRoundInvoked = true;
            }
        }

    }
    
    void NextRound()
    {
        newSceneFlag = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        roundNumber += 1;
        nextRoundInvoked = false;
        playerShot = false;
        roundOver = false;
    }

}
