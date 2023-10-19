using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int coinsCount = 0;
    [SerializeField] private TextMeshProUGUI coinsCountText;

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddCoins()
    {
        coinsCount++;
        coinsCountText.text = coinsCount.ToString();
    }
}
