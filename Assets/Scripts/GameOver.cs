using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryGame() {
        int index = 1;
        GameObject g = GameObject.FindWithTag("DeathManager");
        Debug.Log(g);
        if(g != null) {
            DeathManager dm = g.GetComponent<DeathManager>();
            index = dm.getSceneIndex();
            Debug.Log(index);
        }
        SceneManager.LoadScene(index);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
