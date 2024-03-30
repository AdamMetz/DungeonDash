using UnityEngine;

public class Slime : MonoBehaviour
{
    private Animator animator;
    protected Transform player;
    public float jumpInterval = 1f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("JumpTowardsPlayer", jumpInterval, jumpInterval);
    }

    private void JumpTowardsPlayer()
    {
        animator.SetTrigger("Jump");
    }

    private void Jump()
    {
        Vector2 jumpDirection = (player.position - transform.position).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    // Called at the end of the Jump animation (Jump.anim)
    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    // Check if the player and slime are overlapping, to do damage to the player
    void Update()
    {
        Collider2D[] overlappingColliders = new Collider2D[5];
        int numOverlaps = boxCollider.OverlapCollider(new ContactFilter2D(), overlappingColliders);

        for (int i = 0; i < numOverlaps; i++)
        {
            Collider2D collider = overlappingColliders[i];
            if (collider.CompareTag("Player"))
            {
                CharacterHealth playerHealth = collider.gameObject.GetComponent<CharacterHealth>();
                playerHealth.TakeDamage(1, gameObject.name);
            }
        }
    }

    // Called during the Jump animation, at the point where the slime jumps in air (Jump.anim)
    public void StartJump()
    {
        Jump();
    }
}