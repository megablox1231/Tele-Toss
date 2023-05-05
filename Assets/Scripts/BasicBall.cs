using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball type that teleports player after first hitting ground.
/// </summary>
public class BasicBall : TeleBall
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerTeleported)
        {
            StartCoroutine(TeleportPlayer());
            playerTeleported = true;
        }
        audioSrc.Play();
        audioSrc.volume /= 1.3f;
    }
}
