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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!playerTeleported && !colliding) {
            bounceCount++;
            colliding = true;
            if (bounceCount > maxBounces) {
                TeleportPlayer();
                playerTeleported = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        colliding = false;
    }
}
