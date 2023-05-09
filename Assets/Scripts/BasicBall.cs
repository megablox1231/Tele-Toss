using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball type that teleports player after first hitting ground.
/// </summary>
public class BasicBall : TeleBall
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "kill_bounce" || collision.gameObject.tag == "kill_nobounce") {
            PlayerLife.killPlayer();
        }
        if(collision.gameObject.tag == "Finish") {
            LevelController.win();
        }
        if (!playerTeleported)
        {
            StartCoroutine(TeleportPlayer());
            playerTeleported = true;
        }
        audioSrc.Play();
        audioSrc.volume /= 1.3f;
    }
}
