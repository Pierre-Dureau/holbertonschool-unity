using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private string previousScene;

    private void Start()
    {
        previousScene = GameObject.Find("PreviousScene").GetComponent<PreviousScene>().previousScene;
    }

    public void Back()
    {
        if (previousScene == "MainMenu")
        {
            Destroy(GameObject.Find("PreviousScene"));
        }
        SceneManager.LoadScene(previousScene);
    }
}
