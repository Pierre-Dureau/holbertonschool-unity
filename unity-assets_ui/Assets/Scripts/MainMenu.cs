using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("PreviousScene").GetComponent<PreviousScene>().previousScene = "MainMenu";
    }

    public void LevelSelect(int level)
    {
        GameObject.Find("PreviousScene").GetComponent<PreviousScene>().previousScene = "Level0" + level;
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
