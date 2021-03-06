using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    new private Rigidbody2D rigidbody2D;
    private float horVel = 0f;                              // character horizontal velocity
    private Vector3 velocity = Vector3.zero;                // target velocity of character if nothing is happening
    private float groundRadius = .2f;                       // radius of the point used to determine if grounded

    bool isJumping = false;                                 // check if character wants to jump
    bool isOnGround = false;                                // check if character is on ground
    public bool isLeft;                                     // check if player faces left
    public Animator animator;

    public float speed = 10f;                               // horizontal speed factor
    [SerializeField] private float smoothing = 0.1f;        // factor by which movement smoothing is applied
    public float jumpForce = 17.5f;       // jump force that is applied
    [SerializeField] private LayerMask groundLayer;         // layer on which ground objects should be
    [SerializeField] private Transform groundCheck;         // position which is used to determine if character is on ground

    void Start()
    {
        rigidbody2D = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    void Update()
    {
        // Calculate character velocity in horizontal axis based on which (if any) button is pressed
        horVel = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("VertSpeed", rigidbody2D.velocity.y);

        // Character fliping
        if(Input.GetKeyDown(KeyCode.A))
        {
            isLeft = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isLeft = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        // Check if player pressed Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        // Always set isOnGround value as false
        isOnGround = false;

        // Create array of colliders from ground layer that overlap the character groundCheck
        // if there is any object other than character collider, then set character isOnGroud value as true
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isOnGround = true;
            }
        }
    }

    private void FixedUpdate()
    {
        // Create the vector with target character velocity
        Vector3 targetVelocity = new Vector2(horVel, rigidbody2D.velocity.y);
        // Apply character target velocity and smooth it with SmoothDamp
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, smoothing);



        // If player wants to jump and if character is on ground and if jump is off cooldown, then add force to player rigid body
        if(isJumping && isOnGround)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
