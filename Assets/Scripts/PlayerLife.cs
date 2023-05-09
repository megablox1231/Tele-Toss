using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    public static bool death;
    public static void killPlayer() {
        death = true;
    }

    void Start() {
        death = false;
    }
    void Update() {
        if(death) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Saw")){
            Die();
        }
    }

    private void Die() {
        SceneManager.LoadScene("GameOver");
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
