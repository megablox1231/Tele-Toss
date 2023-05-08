using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Number of available balls for each level
    public int numBall0; // Normal ball
    public int numBall1; // Bouncy ball
    public int numBall2; // Timer ball

    private static int[] balls = new int[3]; // Array to contain the above values

    void Start()
    {
        balls[0] = numBall0;
        balls[1] = numBall1;
        balls[2] = numBall2;
    }

    // Finish the level and go to the next scene
    public static void win() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Decerements the amount of balls left for a type
    public static void decrementBall(int type) {
        if(type >= 0 && type <= 2) {
            balls[type]--;
        }
    }

    // Get the number of balls left for a type
    public static int getNumLeft(int type) {
        if(type >= 0 && type <= 2) {
            return balls[type];
        }
        return 0;
    }
}
