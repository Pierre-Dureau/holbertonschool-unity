using UnityEngine;

public class Goomba : MonoBehaviour
{
    private bool goToLeft = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.x == 0f) {
            goToLeft = !goToLeft;
        }
    }

    private void FixedUpdate()
    {
        if (goToLeft)
            rb.velocity = new Vector2(3f, rb.velocity.y);
        else
            rb.velocity = new Vector2(-3f, rb.velocity.y);
    }
}
