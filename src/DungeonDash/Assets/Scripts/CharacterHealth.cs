using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private bool isImmune = false;
    public float immunityDuration = 0f;
    private float immunityTimer = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Update immunity timer
        if (isImmune)
        {
            immunityTimer -= Time.deltaTime;
            if (immunityTimer <= 0)
            {
                isImmune = false;
            }
        }
    }

    public void TakeDamage(int damageAmount, string projectileSourceName)
    {
        if (isImmune) return;

        // Only deal damage when the player is either being hit or hitting someone
        // This prevents friendly fire between enemies
        if (projectileSourceName == "Player" || gameObject.tag == "Player")
        {
            if (gameObject.tag == "Player")
            {
                damageAmount = 1;
            }

            currentHealth -= damageAmount;
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                CharacterDead();
            }
            else
            {
                isImmune = true;
                immunityTimer = immunityDuration;
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
        if (gameObject.tag != "Player") 
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
        if (gameObject.tag != "Player")
        {
            DropItem item = gameObject.GetComponent<DropItem>();
            if (item != null) item.DropItemOnGround();
            Destroy(gameObject);
        } else if (gameObject.tag == "Player")
        {
            StartCoroutine(HandlePlayerGameOver());
        }
    }

    public IEnumerator HandlePlayerGameOver()
    {
        Animator playerAnimator = GetComponent<Animator>();
        playerAnimator.SetTrigger("GameOver");

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
            playerMovement.enabled = false;

        GameObject playerWeapon = GameObject.Find("Weapon");
        Destroy(playerWeapon);

        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        Destroy(gameObject);
    }
}
