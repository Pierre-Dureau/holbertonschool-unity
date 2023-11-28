using UnityEngine;

public class ButtonIntercation : MonoBehaviour
{
    public void OpenURL(string url) {
        Application.OpenURL(url);
    }
}
