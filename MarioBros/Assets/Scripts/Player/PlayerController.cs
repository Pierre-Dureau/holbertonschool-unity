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
    private Animator animator;

    public static PlayerController instance;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        Flip(rb.velocity.x);

        Jump();

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        if (IsGrounded() && !isJumping)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheckLeft.position, 0.01f, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, 0.01f, groundLayer);
    }

    private void Flip(float _velocity) {
        if (_velocity > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            StartCoroutine(JumpAnim());
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Bounce()
    {
        StartCoroutine(JumpAnim());
        if (Input.GetKey(KeyCode.Space))
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        else
            rb.velocity = new Vector2(rb.velocity.x, jumpForce / 1.5f);
    }

    IEnumerator JumpAnim()
    {
        animator.SetBool("isJumping", true);
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
    }
}
