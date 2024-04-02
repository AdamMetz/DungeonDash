using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GameObject healthPotionPrefab;

    public void DropItemOnGround() 
    {
        if (weaponPrefab != null)
        {
            Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        }
        else if (healthPotionPrefab != null)
        {
            Instantiate(healthPotionPrefab, transform.position, Quaternion.identity);
        }
    }
}
