using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        audioMixer.SetFloat("BGM", LinearToDecibel(PlayerPrefs.GetFloat("BGMSliderValue")));
        audioMixer.SetFloat("Running", LinearToDecibel(PlayerPrefs.GetFloat("SFXSliderValue")) - 20f);
        audioMixer.SetFloat("Landing", LinearToDecibel(PlayerPrefs.GetFloat("SFXSliderValue")) + 2f);
        audioMixer.SetFloat("Ambience", LinearToDecibel(PlayerPrefs.GetFloat("SFXSliderValue")) + 5f);
        audioMixer.SetFloat("Button", LinearToDecibel(PlayerPrefs.GetFloat("SFXSliderValue")) - 5f);
    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        PlayerPrefs.SetString("lastBGM", "wallpaper");
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
    private float LinearToDecibel(float linear)
    {
        if (linear != 0)
            return (20.0f * Mathf.Log10(linear));
        else
            return (-80.0f);
    }
}
