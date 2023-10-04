using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player") 
            other.GetComponent<Timer>().enabled = true;
    }
}
