using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject timerCanvas;
    [SerializeField] private Animator anim;
    [SerializeField] private string AnimName;

    void Start()
    {
        mainCamera.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);
        anim.Play(AnimName);
    }

    public void GameStart()
    {
        gameObject.SetActive(false);
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
    }
}
