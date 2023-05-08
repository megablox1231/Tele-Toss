using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryGame(){
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
