using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball type that teleports player after bouncing a certain amount of times.
/// </summary>
public class BounceBall : TeleBall
{
    [SerializeField] int maxBounces;
    int bounceCount;

    bool colliding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "kill_nobounce") {
            PlayerLife.killPlayer();
        }
        if(collision.gameObject.tag == "Finish") {
            LevelController.win();
        }
        if (!playerTeleported && !colliding) {
            bounceCount++;
            colliding = true;
        }
        if (bounceCount > maxBounces && !playerTeleported) {
            StartCoroutine(TeleportPlayer());
            playerTeleported = true;
        }
        else if(!playerTeleported) {
            audioSrc.Play();
            audioSrc.volume /= 1.3f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }
}
