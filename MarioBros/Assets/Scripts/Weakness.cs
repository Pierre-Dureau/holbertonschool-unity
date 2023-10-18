using System.Collections;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Kill());
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(objectToDestroy);
    }
}
