using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private GameInput gameInput;
    private Rigidbody rb;

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
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);
        if (moveDir !=  Vector3.zero) {
            // Change la direction du vecteur vers la où regarde le player
            moveDir = transform.TransformDirection(moveDir);

            transform.position += moveSpeed * Time.deltaTime * moveDir;
        }
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
