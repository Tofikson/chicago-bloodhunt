using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float horVel = 0f;                              // character horizontal velocity
    private Vector3 velocity = Vector3.zero;                // target velocity of character if nothing is happening
    private float groundRadius = .2f;                       // radius of the point used to determine if grounded
    private float nextJump = 0f;

    bool isJumping = false;                                 // check if character wants to jump
    bool isOnGround = false;                                // check if character is on ground
    bool isJumpReady = true;

    [SerializeField] private float speed = 10f;             // horizontal speed factor
    [SerializeField] private float smoothing = 0.1f;        // factor by which movement smoothing is applied
    [SerializeField] private float jumpForce = 17.5f;       // jump force that is applied
    [SerializeField] private LayerMask groundLayer;         // layer on which ground objects should be
    [SerializeField] private Transform groundCheck;         // position which is used to determine if character is on ground
    [SerializeField] private float groundSlamForce = 5f;    // force to be applied if the player presses down button while in air
    [SerializeField] private float jumpCooldown = 0.05f;       // cooldoown in seconds

    void Start()
    {
        rigidbody2D = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    void Update()
    {
        // Calculate character velocity in horizontal axis based on which (if any) button is pressed
        horVel = Input.GetAxisRaw("Horizontal") * speed;

        // Check if player pressed Spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        
        // logic of the jump cooldown. If jump is not ready, check if jumpCooldown is bigger than nextJump.
        // If true, add time from the last frame to nextJump variable. 
        // If false switch isJumpReady to true and clear the NextJump variable
        if (!isJumpReady)
        {
            if (jumpCooldown > nextJump)
            {
                nextJump += Time.deltaTime;
            }
            else
            {
                isJumpReady = true;
                nextJump = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        // Create the vector with target character velocity
        Vector3 targetVelocity = new Vector2(horVel, rigidbody2D.velocity.y);
        // Apply character target velocity and smooth it with SmoothDamp
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, smoothing);

        // Always set isOnGround value as false
        isOnGround = false;

        // Create array of colliders from ground layer that overlap the character groundCheck
        // if there is any object other than character collider, then set character isOnGroud value as true
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayer);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                isOnGround = true;
            }
        }

        // If player wants to jump and if character is on ground and if jump is off cooldown, then add force to player rigid body
        if(isJumping && isOnGround && isJumpReady)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumpReady = false;
        }

        // If player wants to make his fall faster, he can press the DOWN button, and is in air, add vertical force towards the ground
        if (Input.GetAxisRaw("Vertical") == -1f && !isOnGround)
        {
            rigidbody2D.AddForce(new Vector2(0f, groundSlamForce *-1), ForceMode2D.Impulse);
        }
    }
}
