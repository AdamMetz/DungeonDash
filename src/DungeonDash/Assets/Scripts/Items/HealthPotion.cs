using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") {
            CharacterHealth playerHealth = collision.gameObject.GetComponent<CharacterHealth>();
            if (playerHealth.Heal(1)) Destroy(gameObject);
        }
    }
}
