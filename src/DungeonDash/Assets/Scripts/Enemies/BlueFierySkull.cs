using UnityEngine;

public class BlueFierySkull : FierySkull
{
    public override void Fire()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Shotgun style attack
        ShootProjectile(directionToPlayer);
        ShootProjectile(Quaternion.Euler(0, 0, 20) * directionToPlayer);
        ShootProjectile(Quaternion.Euler(0, 0, -20) * directionToPlayer);
    }

    private void ShootProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().parent = gameObject.name;

        // Rotate projectile to face player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Shoot towards the player
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<Projectile>().speed;
    }
}