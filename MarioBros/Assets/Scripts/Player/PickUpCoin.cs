using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory.instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
