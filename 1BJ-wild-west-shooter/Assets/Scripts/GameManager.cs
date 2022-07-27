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
    private GameObject generator;
    private PersonGen gen_script;

    private bool playerShot;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gen_script = generator.GetComponent<PersonGen>();

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
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (roundOver == true)
        {
            // determine outcome

            // LOSE: didn't shoot baddie
            if ((playerShot = false) && (generator.GetComponent<PersonGen>().guilty == true))
            {
                // animation of player being shot
                // then go to lose screen
                // possible lose screen: player's own funeral
            }
            // LOSE: shot innocent
            else if ((playerShot = true) && (generator.GetComponent<PersonGen>().guilty == false))
            {
                // possible lose screen: player attends their funeral
            }

            // WIN: didn't shoot innocent
            else if ((playerShot = false) && (generator.GetComponent<PersonGen>().guilty == false))
            {
                // animation or sound effect of innocent being relieved (phew)
                // then next person
            }
            // WIN: shot baddie
            if ((playerShot = true) && (generator.GetComponent<PersonGen>().guilty == true))
            {
                // animation and sound effect of baddie going down
                // then next person
            }

            // wait two seconds
            // reload the gameplay scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerShot = false;
            roundOver = false;
        }
    }
}
