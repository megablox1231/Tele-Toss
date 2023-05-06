using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball type that teleports player at its position after a set amount of time,
/// or teleports when the player clicks before the timer is up.
/// </summary>
public class TimerBall : TeleBall
{
    [SerializeField] float waitTime;

    protected override void Start() {
        base.Start();
        StartCoroutine(TimedTeleport());
    }

    void Update() {
        if (Input.GetMouseButtonUp(0) && !playerTeleported) {
            StartCoroutine(TeleportPlayer());
            playerTeleported = true;
        }
    }

    IEnumerator TimedTeleport() {
        yield return new WaitForSeconds(waitTime);
        if (!playerTeleported)
        {
            playerTeleported = true;
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Finish") {
            LevelController.win();
        }
        audioSrc.Play();
        audioSrc.volume /= 1.3f;
    }
}
