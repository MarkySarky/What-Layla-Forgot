using Ink.Parsed;
using UnityEditor;
using UnityEngine;

// This script is a basic 2D character controller that allows
// the player to run and jump. It uses Unity's new input system,
// which needs to be set up accordingly for directional movement
// and jumping buttons.
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Params")]
    public float runSpeed = 216.0f;
    public float jumpSpeed = 318.0f;
    public float gravityScale = 20.0f;

    // Animator
    public Animator animator;

    // components attached to player
    private CapsuleCollider2D coll;
    private Rigidbody2D rb;

    // other
    private bool isGrounded = false;
    bool facingRight = true;

    //SFX
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource walk;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;
    }

    private void FixedUpdate()
    {
        //if (DialogueManager.GetInstance().dialogueIsPlaying)
        //{
        //    return;
        //}

        UpdateIsGrounded();

        HandleHorizontalMovement();

        HandleJumping();
    }

    private void UpdateIsGrounded()
    {

        Debug.Log("Update is grounded");
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        this.isGrounded = false;
        animator.SetBool("isJumping", true);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != coll)
                {
                    this.isGrounded = true;
                    animator.SetBool("isJumping", false);
                    break;
                }
            }
        }
    }

    private void HandleHorizontalMovement()
    {
        Debug.Log("moving through characterMovement");
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        rb.velocity = new Vector2(moveDirection.x * runSpeed, rb.velocity.y);

        if (moveDirection.x < 0 && facingRight)// if you press the left arrw and you're facing right then you will face left;
        {
            flip();
        }
        else if (moveDirection.x > 0 && !facingRight)// if you press the right arrrow an you are facing left then you will face right;
        {
            flip();
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.x != 0 && isGrounded)
        {
            if (!walk.isPlaying)
            {
                walk.Play();
            }
        }
        else
        {
            walk.Stop();
        }
}

private void HandleJumping()
    {
        bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
        if (isGrounded && jumpPressed)
        {
            isGrounded = false;
            jump.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    void flip()
    {
        facingRight = !facingRight;// if facing right is true it will be false and if it is false it will be true
        transform.Rotate(0f, 180f, 0f);
    }
}