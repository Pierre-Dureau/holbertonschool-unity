using System.Collections;
using UnityEngine;

public class GoombaWeakness : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private GameObject controlToDestroy;
    [SerializeField] private Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.Bounce();
            StartCoroutine(Kill());
        }
    }

    IEnumerator Kill()
    {
        animator.SetBool("isDead", true);
        Destroy(controlToDestroy);
        yield return new WaitForSeconds(0.4f);
        Destroy(objectToDestroy);
    }
}
