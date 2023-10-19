using UnityEngine;

public class GoombaController : MonoBehaviour
{
    private bool goToLeft = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (goToLeft)
            rb.velocity = new Vector2(3f, rb.velocity.y);
        else
            rb.velocity = new Vector2(-3f, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("death");
        goToLeft = !goToLeft;
    }
}
