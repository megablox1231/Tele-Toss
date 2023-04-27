using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball type that teleports player at its position after
/// a set amount of time.
/// </summary>
public class TimerBall : TeleBall
{
    [SerializeField] float waitTime;

    protected override void Start() {
        base.Start();
        StartCoroutine(TimedTeleport());
    }

    IEnumerator TimedTeleport() {
        yield return new WaitForSeconds(waitTime);
        TeleportPlayer();
    }

}
