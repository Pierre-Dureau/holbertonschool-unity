using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float horizontalMovement;
    private bool isJumping = false;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        Flip(rb.velocity.x);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            StartCoroutine(Jump());
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (IsGrounded() && !isJumping)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheckLeft.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, 0.1f, groundLayer);
    }

    private void Flip(float _velocity) {
        if (_velocity > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    IEnumerator Jump()
    {
        animator.SetBool("isJumping", true);
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("isJumping"))
        {
            if (Input.GetKey(KeyCode.Space))
                rb.velocity = new Vector2(rb.velocity.x, 19f);
            else
                rb.velocity = new Vector2(rb.velocity.x, 8f);
        }
    }
}
