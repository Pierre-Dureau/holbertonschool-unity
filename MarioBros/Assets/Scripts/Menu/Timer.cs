using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 301;
    private int seconds;
    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
            seconds = Mathf.FloorToInt(timer);
            timerText.text = string.Format("{0:000}", seconds);
        }
        else
            Debug.Log("death");
    }
}
