using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int coinsCount = 0;
    [SerializeField] private TextMeshProUGUI coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddCoins()
    {
        coinsCount++;
        coinsCountText.text = coinsCount.ToString();
    }
}
