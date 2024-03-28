using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount) 
    {
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
