using UnityEngine;

public class FierySkull : MonoBehaviour
{
    public GameObject projectilePrefab;
    protected Transform player;

    public float movementSpeed = 1.5f;

    public float movementDuration = 2f;
    public float stopDuration = 2f;

    private bool isMoving = true;
    private bool recentlyShot = false;

    private Vector3 movementDirection;

    private float movementTimer = 0f;
    private float stopTimer = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateMovementDirection();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveEnemy();

            // Increment a timer while moving, and stop and shoot when timer is reached
            movementTimer += Time.deltaTime;
            if (movementTimer >= movementDuration)
            {
                stopTimer = 0f;
                isMoving = false;
            }
        }
        else
        {
            stopTimer += Time.deltaTime;
            // Stop for half the stop duration, shoot, stop for the remainder of the duration, then begin moving
            if (stopTimer >= stopDuration / 2 && !recentlyShot)
            {
                Fire();
                recentlyShot = true;
            }
            else if (stopTimer >= stopDuration)
            {
                recentlyShot = false;
                isMoving = true;
                movementTimer = 0f;
                UpdateMovementDirection();
            }
        }
    }

    void MoveEnemy()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    void UpdateMovementDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        movementDirection = new Vector3(randomDirection.x, randomDirection.y, 0);
    }

    public virtual void Fire()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().parent = gameObject.name;

        // Rotate projectile to face player
        Vector3 projectileDirection = player.position - projectile.transform.position;
        float angle = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Shoot towards the player
        projectile.GetComponent<Rigidbody2D>().velocity = directionToPlayer * projectile.GetComponent<Projectile>().speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce off the wall if ran into
        if (collision.gameObject.name == "WallsTilemap")
        {
            Vector2 normalVector = collision.contacts[0].normal;
            movementDirection = Vector2.Reflect(movementDirection, normalVector);
        }
    }
}