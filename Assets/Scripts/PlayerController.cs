using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundDrag = 5f;
    [SerializeField] private float airDrag = 2f;

    [Header("Ground Check")]
    [SerializeField] private float groundDragDistance = 0.2f;
    [SerializeField] private LayerMask Ground;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private float verticalVelocity;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        CheckGrounded();
        HandleJump();
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void CheckGrounded()
    {
        Vector2 boxSize = new Vector2(0.7f, 0.1f);
        Vector2 boxPosition = (Vector2)transform.position - new Vector2(0, 0.3f);

        isGrounded = Physics2D.OverlapBox(boxPosition, boxSize, 0, Ground);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void UpdateAnimations()
    {
        if (animator == null) return;

        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isFalling", rb.velocity.y < -0.1f && !isGrounded);

        if (horizontalInput > 0.1f)
        {
            animator.SetFloat("Speed", 1f);
            if (!facingRight) Flip();
        }
        else if (horizontalInput < -0.1f)
        {
            animator.SetFloat("Speed", 1f);
            if (facingRight) Flip();
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RespawnPlayer();
        }
    }
}