using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Toggle yAxis;

    private void Start()
    {
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
        if (yAxis.isOn == true)
            PlayerPrefs.SetInt("yAxis", 1);
        else
            PlayerPrefs.SetInt("yAxis", 0);

        Back();
    }
}
