using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private CameraController controller;
    private bool gamePaused = false;


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
        controller.enabled = false;
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
        gamePaused = true;
    }

    public void Resume()
    {
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
