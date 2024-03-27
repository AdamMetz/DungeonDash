using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public string parent;
    public float rotationOffset = 0f; // Some assets are angled by defualt, so its sometimes necessary to add a rotation offset

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the rotation of the projectile in Euler angles
        float angle = transform.eulerAngles.z + rotationOffset;

        // Convert the angle to radians
        float angleRadians = angle * Mathf.Deg2Rad;

        // Calculate the direction based on the angle
        Vector2 shootDirection = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));

        // Set the velocity in the direction the projectile is rotated
        rb.velocity = shootDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(parent);
        print(collision.name);
        if (!collision.name.Contains(parent))
        {
            Destroy(gameObject);
        }
    }

}
