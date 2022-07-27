using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int roundNumber;
    public bool roundOver = false;

    private int playerScore;
    private int pointsForRound;

    // fetch the person generator
    public GameObject clock;
    private Timer timer;

    public GameObject person;
    private PersonGen personGen;
    private bool newSceneFlag = false;

    private bool playerShot;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerShot = false;
    }

    // Update is called once per frame
    void Update()
    {   
        // The Player Button 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Gameplay"))
            {
                playerShot = true;
                roundOver = true;
            }
            else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainMenu")) 
            {
                SceneManager.LoadScene("Gameplay");
            }
            else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("GameOver")) 
            {
                newSceneFlag = false;
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (newSceneFlag == false && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
        {
            GameObject newClock = Instantiate(clock);
            GameObject newPerson = Instantiate(person);
            personGen = newPerson.GetComponent<PersonGen>();
            newSceneFlag = true;
        }

        if (roundOver == true)
        {
            // determine outcome
            // LOSE: didn't shoot baddie
            if ((playerShot == false) && (personGen.guilty == true))
            {
                // animation of player being shot
                // then go to lose screen
                // possible lose screen: player's own funeral
                SceneManager.LoadScene("GameOver");
            }
            // LOSE: shot innocent
            else if ((playerShot == true) && (personGen.guilty == false))
            {
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

            // wait two seconds
            StartCoroutine(NextRound());
        }
    }

    IEnumerator NextRound()
    {
        // reload the gameplay scene
        newSceneFlag = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerShot = false;
        roundOver = false;

        yield return new WaitForSeconds(2f);
    }
}
