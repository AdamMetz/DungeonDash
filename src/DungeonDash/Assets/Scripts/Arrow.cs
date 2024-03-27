using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public string parent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the rotation of the arrow in Euler angles
        float angle = transform.eulerAngles.z + 135f;

        // Convert the angle to radians
        float angleRadians = angle * Mathf.Deg2Rad;

        // Calculate the direction based on the angle
        Vector2 shootDirection = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));

        // Set the velocity in the direction the arrow is rotated
        rb.velocity = shootDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Contains(parent))
        {
            Destroy(gameObject);
        }
    }

}
