using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Toggle yAxis;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip wallpaper;
    [SerializeField] private AudioClip cheerymonday;
    [SerializeField] private AudioClip porchswingdays;
    [SerializeField] private AudioClip brittlerille;

    private void Start()
    {
        switch (PlayerPrefs.GetString("lastBGM"))
        {
            case "wallpaper": audioSource.clip = wallpaper; break;
            case "cheerymonday": audioSource.clip = cheerymonday; break;
            case "porchswingdays": audioSource.clip = porchswingdays; break;
            case "brittlerille": audioSource.clip = brittlerille; break;
        }
        audioSource.Play();

        BGMSlider.value = PlayerPrefs.GetFloat("BGMSliderValue", 1f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSliderValue", 1f);

        if (PlayerPrefs.GetInt("yAxis") == 1)
            yAxis.isOn = true;
        else
            yAxis.isOn = false;
    }

    private void Update()
    {
        audioMixer.SetFloat("BGM", LinearToDecibel(BGMSlider.value));
        audioMixer.SetFloat("Button", LinearToDecibel(SFXSlider.value) - 5f);
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("BGMSliderValue", BGMSlider.value);
        PlayerPrefs.SetFloat("SFXSliderValue", SFXSlider.value);

        audioMixer.SetFloat("Running", LinearToDecibel(SFXSlider.value) - 20f);
        audioMixer.SetFloat("Landing", LinearToDecibel(SFXSlider.value) + 2f);
        audioMixer.SetFloat("Ambience", LinearToDecibel(SFXSlider.value) + 5f);

        if (yAxis.isOn == true)
            PlayerPrefs.SetInt("yAxis", 1);
        else
            PlayerPrefs.SetInt("yAxis", 0);

        Back();
    }

    private float LinearToDecibel(float linear)
    {
        if (linear != 0)
            return (20.0f * Mathf.Log10(linear));
        else
            return (-80.0f);
    }
}
