using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
