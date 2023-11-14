using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip running_grass;
    [SerializeField] private AudioClip running_rock;
    [SerializeField] private AudioClip landing_grass;
    [SerializeField] private AudioClip landing_rock;
    [SerializeField] private AudioSource audioSourceRun;
    [SerializeField] private AudioSource audioSourceLand;

    [SerializeField] private PlayerController playerController;

    public void Step()
    {
        if (playerController.platformTag == "Grass")
            audioSourceRun.PlayOneShot(running_grass);
        else
            audioSourceRun.PlayOneShot(running_rock);
    }

    public void Land()
    {
        if (playerController.platformTag == "Grass")
            audioSourceLand.PlayOneShot(landing_grass);
        else
            audioSourceLand.PlayOneShot(landing_rock);
    }
}
