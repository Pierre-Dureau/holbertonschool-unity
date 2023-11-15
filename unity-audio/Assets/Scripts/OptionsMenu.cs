using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Toggle yAxis;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMSliderValue");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSliderValue");

        if (PlayerPrefs.GetInt("yAxis") == 1)
            yAxis.isOn = true;
        else
            yAxis.isOn = false;
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("BGMSliderValue", BGMSlider.value);
        PlayerPrefs.SetFloat("SFXSliderValue", SFXSlider.value);

        if (yAxis.isOn == true)
            PlayerPrefs.SetInt("yAxis", 1);
        else
            PlayerPrefs.SetInt("yAxis", 0);

        Back();
    }
}
