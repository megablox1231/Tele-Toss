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
            player.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    IEnumerator TimedTeleport() {
        yield return new WaitForSeconds(waitTime);
        TeleportPlayer();
    }

}
