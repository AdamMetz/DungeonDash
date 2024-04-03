using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public string parent;
    public float rotationOffsetx = 0f; // Some assets are angled by defualt, so its sometimes necessary to add a rotation offset
    public float rotationOffsety = 0f;
    public float rotationOffsetz = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the rotation of the projectile in Euler angles
        float angle = transform.eulerAngles.z;
        float angleRadians = angle * Mathf.Deg2Rad;

        // Calculate the direction based on the angle
        Vector2 shootDirection = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));

        // Set the velocity in the direction the projectile is rotated
        rb.velocity = shootDirection * speed;

        transform.localRotation *= Quaternion.Euler(rotationOffsetx, rotationOffsety, rotationOffsetz);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Contains(parent))
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) 
            {
                CharacterHealth characterHealth = collision.gameObject.GetComponent<CharacterHealth>();
                characterHealth.TakeDamage(damage, parent);
            }
            Destroy(gameObject);
        }
    }

}
