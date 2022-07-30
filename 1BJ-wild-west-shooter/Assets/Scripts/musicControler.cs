using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicControler : MonoBehaviour
{
    public AudioClip[] music;
    public AudioClip[] SFX;
    private AudioSource audioSource;
    private GameManager gameManagerScript;

    private void Awake()
    {
        gameManagerScript = GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // in the main menu loop the intro sound
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {

            if (!audioSource.isPlaying || audioSource.clip == music[2])
            {
                audioSource.clip = music[0];
                audioSource.Play(0);
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
        {
            if (audioSource.clip == music[0])
            {
                audioSource.Stop();
                audioSource.volume = 0.08f;
                audioSource.clip = music[1];
                audioSource.Play(0);
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            if (audioSource.clip == music[1])
            {
                audioSource.Stop();
                audioSource.volume = 0.45f;
                audioSource.clip = music[2];
                audioSource.Play(0);
            }
        }
    }
}
