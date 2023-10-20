using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private bool check = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (check && collision.gameObject.CompareTag("Player"))
        {
            check = false;
            Inventory.instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
