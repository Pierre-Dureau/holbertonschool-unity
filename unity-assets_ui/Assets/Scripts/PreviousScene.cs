using UnityEngine;

public class PreviousScene : MonoBehaviour
{
    public string previousScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
