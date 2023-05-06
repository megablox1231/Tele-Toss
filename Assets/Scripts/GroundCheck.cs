using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks if player is grounded. Plays related animation and audio when appropriate.
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    BoxCollider2D coll;
    Animator animator;

    AudioSource audio;
    [SerializeField] AudioClip landingClip;

    bool grounded;
    bool lastFrameGrounded;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        grounded = IsGrounded();
        animator.SetBool("Grounded", grounded);
        if (grounded && !lastFrameGrounded)
        {
            audio.clip = landingClip;
            audio.Play();
        }
        lastFrameGrounded = grounded;
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundMask);
    }
}
