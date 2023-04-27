using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all TeleBall types.
/// Handles ground checks and teleporting.
/// </summary>
public class TeleBall : MonoBehaviour
{
    protected float teleportOffset;
    [HideInInspector] public Transform player;
    protected bool playerTeleported;

    [SerializeField] LayerMask groundCheckMask;
    BoxCollider2D groundCollider;
    float radius;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;
        groundCollider = GetComponentInChildren<BoxCollider2D>();
        teleportOffset = player.GetComponent<BoxCollider2D>().size.y / 2 - radius;
    }

    protected bool GroundCheck() 
    {
        return groundCollider.IsTouchingLayers(groundCheckMask);
    }

    protected void TeleportPlayer(Collision2D collision) {
        // If collider below ball, offset teleport position up 
        if (collision.collider.ClosestPoint(transform.position - Vector3.up * radius).y < (transform.position - Vector3.up * radius).y) {
            player.transform.position = transform.position + Vector3.up * teleportOffset;
        }
        else {
            player.transform.position = transform.position - Vector3.up * teleportOffset;
        }
    }

    protected void TeleportPlayer() {
        player.transform.position = transform.position + Vector3.up * teleportOffset;
    }
}
