using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip gameOverMusic;
    public AudioClip bgMusic;

    public AudioClip mainMenuMusic;

    AudioSource aus;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        aus = GetComponent<AudioSource>();
        
        if(!aus.isPlaying) {
            aus.Play();
        }
    }

    void Update() {
        if(SceneManager.GetActiveScene().name == "MainMenu") {
            if(aus.clip != mainMenuMusic) {
                aus.Stop();
                aus.clip = mainMenuMusic;
                aus.Play();
            }
        }
        else if(SceneManager.GetActiveScene().name == "GameOver") {
            if(aus.clip != gameOverMusic) {
                aus.Stop();
                aus.clip = gameOverMusic;
                aus.Play();

            }
        }
        else {
            if(aus.clip != bgMusic) {
                aus.Stop();
                aus.clip = bgMusic;
                aus.Play();
            }
        }
    }
}
