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
        if (currentHealth <= 0 ) 
        {
            CharacterDead();
        }
    }

    private void CharacterDead() 
    {
        Destroy(gameObject);
    }
}
