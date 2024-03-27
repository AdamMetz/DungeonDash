using UnityEngine;

public class FierySkull : MonoBehaviour
{
    public float movementSpeed = 1.5f;
    public float movementDuration = 2f;
    public float stopDuration = 2f;
    private bool isMoving = true;
    private Vector3 movementDirection;
    private float movementTimer = 0f;
    private float stopTimer = 0f;

    private void Start()
    {
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
        } else
        {
            stopTimer += Time.deltaTime;
            if (stopTimer >= stopDuration)
            {
                movementTimer = 0f;
                isMoving = true;
            }
            UpdateMovementDirection();
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