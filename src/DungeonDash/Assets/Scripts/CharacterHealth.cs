using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount, string projectileSourceName)
    {
        // Only deal damage when the player is either being hit or hitting someone
        // This prevents friendly fire between enemies
        if (projectileSourceName == "Player" || gameObject.name == "Player")
        {
            print(projectileSourceName);
            print(gameObject.name);
            if (gameObject.name == "Player")
            {
                damageAmount = 1;
            }

            currentHealth -= damageAmount;
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                CharacterDead();
            }
        }
    }

    // Heal the player if possible and return true, otherwise return false if the player is already max hp
    public bool Heal(int healAmount) 
    {
        if (currentHealth + healAmount <= maxHealth) { 
            currentHealth += healAmount;
            UpdateHealthBar();
            return true;
        }
        return false;
    }

    private void UpdateHealthBar()
    {
        if (gameObject.name != "Player") 
        {
            EnemyHealthBar enemyHealthBar = transform.Find("HealthBar")?.GetComponent<EnemyHealthBar>();
            enemyHealthBar.UpdateHealthBar((float)currentHealth / maxHealth);
        } else
        {
            PlayerHealthBar playerHealthBar = transform.Find("Canvas").Find("Hearts").GetComponent<PlayerHealthBar>();
            playerHealthBar.UpdateHealthBar(currentHealth);
        }
    }

    private void CharacterDead() 
    {
        if (gameObject.name != "Player") // TEMPORARY: Until we handle player death
        {
            Destroy(gameObject);
        }
    }
}
