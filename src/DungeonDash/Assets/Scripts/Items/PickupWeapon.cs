using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public int weaponDamage = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Weapon playerWeapon = collision.gameObject.transform.Find("Weapon").GetComponent<Weapon>();
            playerWeapon.EquipNewWeapon(weaponDamage, GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}
