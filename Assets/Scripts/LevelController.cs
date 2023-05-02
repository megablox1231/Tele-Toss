using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Number of available balls for each level
    public int numBall0; // Normal ball
    public int numBall1; // Bouncy ball
    public int numBall2; // Timer ball

    private static int[] balls = new int[3]; // Array to contain the above values

    public Font font;

    void OnGUI() {
        GUI.skin.font = font;
        GUI.Label(new Rect(830, 112, 100, 100), "x" + balls[0]);
        GUI.Label(new Rect(830, 160, 100, 100), "x" + balls[1]);
        GUI.Label(new Rect(830, 208, 100, 100), "x" + balls[2]);
    }

    void Start()
    {
        balls[0] = numBall0;
        balls[1] = numBall1;
        balls[2] = numBall2;
    }

    void Update()
    {
        
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
