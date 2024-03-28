using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount) 
    {
        currentHealth -= damageAmount;
        print(gameObject.name + " Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            CharacterDead();
        }
        else if (gameObject.name != "Player") UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        EnemyHealthBar enemyHealthBar = transform.Find("HealthBar")?.GetComponent<EnemyHealthBar>();
        enemyHealthBar.UpdateHealthBar((float) currentHealth / maxHealth);
    }

    private void CharacterDead() 
    {
        Destroy(gameObject);
    }
}
