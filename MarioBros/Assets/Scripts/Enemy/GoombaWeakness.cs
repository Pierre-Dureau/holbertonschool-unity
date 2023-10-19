using System.Collections;
using UnityEngine;

public class GoombaWeakness : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private GameObject controlToDestroy;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Jump();
            StartCoroutine(Kill());
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.velocity = new Vector2(rb.velocity.x, 19f);
        else
            rb.velocity = new Vector2(rb.velocity.x, 10f);
    }

    IEnumerator Kill()
    {
        animator.SetBool("isDead", true);
        Destroy(controlToDestroy);
        yield return new WaitForSeconds(0.4f);
        Destroy(objectToDestroy);
    }
}
