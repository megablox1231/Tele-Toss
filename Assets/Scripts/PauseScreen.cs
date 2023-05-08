using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Logic of pause screen, including pausing, resuming, and quitting.
/// </summary>
public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;

    public static bool gamePaused = false;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music != null)
        {
            music.GetComponent<AudioSource>().Pause();
        }
        gamePaused = true;
    }

    public void Resume() {
        StartCoroutine(ResumeHelper());
    }

    // Ensures mouse input not picked up by PlayerTeleportation
    IEnumerator ResumeHelper() {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music != null) {
            music.GetComponent<AudioSource>().UnPause();
        }
        gamePaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void QuitGame() {
        Application.Quit();
        EventSystem.current.SetSelectedGameObject(null);
    }
}
