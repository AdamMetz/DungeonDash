using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject bowPrefab;
    public GameObject staffPrefab;
    public GameObject healthPotionPrefab;

    private string playerClass = "";

    private void GetPlayerClass() 
    {
        playerClass = GameObject.FindGameObjectWithTag("Player").gameObject.name;
    }
    public void DropItemOnGround() 
    {
        GetPlayerClass();

        if (bowPrefab != null && playerClass == "Archer")
        {
            Instantiate(bowPrefab, transform.position, Quaternion.identity);
        }
        else if (staffPrefab != null && playerClass == "Mage")
        {
            Instantiate(staffPrefab, transform.position, Quaternion.identity);
        }
        else if (healthPotionPrefab != null)
        {
            Instantiate(healthPotionPrefab, transform.position, Quaternion.identity);
        }
    }
}
