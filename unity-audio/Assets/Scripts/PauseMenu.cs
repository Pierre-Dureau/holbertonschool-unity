using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private CameraController controller;
    private bool gamePaused = false;

    [SerializeField] private AudioMixerSnapshot pausedSnapshot;
    [SerializeField] private AudioMixerSnapshot unpausedSnapshot;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pausedSnapshot.TransitionTo(0.01f);
        controller.enabled = false;
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
        gamePaused = true;
    }

    public void Resume()
    {
        unpausedSnapshot.TransitionTo(0.01f);
        controller.enabled = true;
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Resume();
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
}
