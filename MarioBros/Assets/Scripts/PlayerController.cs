using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float horizontalMovement;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        Flip(rb.velocity.x);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip(float _velocity) {
        if (_velocity > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }
}
