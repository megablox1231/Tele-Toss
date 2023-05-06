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
    protected float halfLength;
    protected float halfHeight;
    [HideInInspector] public Transform player;
    protected bool playerTeleported;

    protected AudioSource audioSrc;

    [SerializeField] LayerMask raycastMask;
    BoxCollider2D groundCollider;
    float radius;


    virtual protected void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        radius = GetComponent<CircleCollider2D>().radius;
        groundCollider = GetComponentInChildren<BoxCollider2D>();
        BoxCollider2D playerColl = player.GetComponent<BoxCollider2D>();
        teleportOffset = playerColl.size.y / 2 - radius;
        halfHeight = playerColl.size.y / 2;
        halfLength = playerColl.size.x / 2;
    }

    protected bool GroundCheck() 
    {
        return groundCollider.IsTouchingLayers(raycastMask);
    }

    protected IEnumerator TeleportPlayer()
    {
        // Hold position of ball at collision to teleport to later
        Vector3 telePos = transform.position;

        PlayerTeleportation playerTeleport = player.GetComponent<PlayerTeleportation>();
        playerTeleport.TeleportAudioVisuals();
        // Wait until teleport animation is done to actually move player
        yield return new WaitForSeconds(playerTeleport.teleportTime);

        RaycastHit2D hitUp = Physics2D.BoxCast(telePos, new Vector2(radius * 2, 0.001f), 0, Vector2.up, halfHeight, raycastMask);
        RaycastHit2D hitRight = Physics2D.BoxCast(telePos, new Vector2(0.001f, radius * 2), 0, Vector2.right, halfLength, raycastMask);
        RaycastHit2D hitDown = Physics2D.BoxCast(telePos, new Vector2(radius * 2, 0.001f), 0, Vector2.down, halfHeight, raycastMask);
        RaycastHit2D hitLeft = Physics2D.BoxCast(telePos, new Vector2(0.001f, radius * 2), 0, Vector2.left, halfLength, raycastMask);

        Vector3 offset = Vector3.zero;
        if (hitUp.collider != null) 
        {
            offset.y -= halfHeight - hitUp.distance;
        }
        if (hitRight.collider != null)
        {
            offset.x -= halfLength - hitRight.distance;
        }
        if (hitDown.collider != null)
        {
            offset.y += halfHeight - hitDown.distance;
        }
        if (hitLeft.collider != null)
        {
            offset.x += halfLength - hitLeft.distance;
        }

        player.transform.position = telePos + offset;
        Destroy(gameObject);
    }    
}
