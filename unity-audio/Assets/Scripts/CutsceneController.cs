using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject timerCanvas;

    void Start()
    {
        mainCamera.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(2.1f);
        gameObject.SetActive(false);
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
    }
}
