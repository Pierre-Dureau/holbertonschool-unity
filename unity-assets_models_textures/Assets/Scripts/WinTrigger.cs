using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            other.GetComponent<Timer>().enabled = false;
            other.GetComponent<Timer>().TimerText.fontSize = 60;
            other.GetComponent<Timer>().TimerText.color = Color.green;
        }
    }
}
