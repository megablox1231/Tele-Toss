using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryGame() {
        int index = 1;
        GameObject g = GameObject.FindWithTag("DeathManager");
        if(g != null) {
            DeathManager dm = g.GetComponent<DeathManager>();
            index = dm.getSceneIndex();
        }
        SceneManager.LoadScene(index);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
