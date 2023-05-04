using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //this takes it to the next level
    }

    public void QuitGame(){
        Application.Quit();
    }
}
