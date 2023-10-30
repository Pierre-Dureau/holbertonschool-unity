using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas timerCanvas;
    [SerializeField] private CameraController controller;

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            timerCanvas.gameObject.SetActive(false);
            winCanvas.gameObject.SetActive(true);
            controller.enabled = false;
            other.GetComponent<Timer>().Win();
        }
    }
}
