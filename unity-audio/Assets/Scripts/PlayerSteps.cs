using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    [SerializeField] private AudioClip running_grass;
    [SerializeField] private AudioClip running_rock;
    private AudioSource audioSource;
    private AudioClip clip;

    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Step()
    {
        if (playerController.platformTag == "Grass")
            clip = running_grass;
        else
            clip = running_rock;
        audioSource.PlayOneShot(clip);
    }
}
