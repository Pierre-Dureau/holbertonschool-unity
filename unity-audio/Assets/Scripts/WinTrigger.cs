using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas timerCanvas;
    [SerializeField] private CameraController controller;
    [SerializeField] private AudioSource BGM;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            if (BGM != null)
                BGM.Pause();
            audioSource.Play();
            timerCanvas.gameObject.SetActive(false);
            winCanvas.gameObject.SetActive(true);
            controller.enabled = false;
            other.GetComponent<Timer>().Win();
        }
    }
}
