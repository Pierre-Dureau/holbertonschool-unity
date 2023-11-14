using UnityEngine;
using System.Collections;

public class TimerTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player") {
            other.GetComponent<Timer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (playerController.isDead == true && other.name == "Player") {
            animator.SetBool("isFalling", false);
            animator.SetBool("Impact", true);
            StartCoroutine(CancelMovementAfterFall());
        }
    }

    IEnumerator CancelMovementAfterFall() {
        yield return new WaitForSeconds(9f);
        playerController.isDead = false;
    }
}
