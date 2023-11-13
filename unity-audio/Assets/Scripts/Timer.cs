using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float currentTime = 0f;
    [SerializeField] private TextMeshProUGUI winText;

    private void Update()
    {
        currentTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int milliseconds = Mathf.FloorToInt((currentTime * 100) % 100);
        
        TimerText.text = string.Format("{0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void Win()
    {
        winText.text = TimerText.text;
        Time.timeScale = 0;
    }
}
