using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        Time.timeScale = 1.0f;
        int numScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings != numScene)
            SceneManager.LoadScene(numScene);
        else
            SceneManager.LoadScene(0);
    }
}
