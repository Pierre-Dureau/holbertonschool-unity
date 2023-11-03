using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float moveSpeed = 8f;
    private readonly float jumpPower = 9f;
    [SerializeField] private GameInput gameInput;
    private Rigidbody rb;
    [SerializeField] private Transform cam;
    [SerializeField] private Animator animator;

    float turnSmoothVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (transform.position.y < -10)
            transform.position = new Vector3(0f, 5f, 0f);
    }


    void FixedUpdate()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 direction = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        if (direction.magnitude >= 0.1f) {
            animator.SetBool("isRunning", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveSpeed * Time.deltaTime * moveDir.normalized;
        }
        else
            animator.SetBool("isRunning", false);

        rb.AddForce(15f * rb.mass * Vector3.down);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, 1.25f);
    }    
}
