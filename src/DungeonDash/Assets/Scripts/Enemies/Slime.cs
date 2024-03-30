using UnityEngine;

public class Slime : MonoBehaviour
{
    private Animator animator;
    protected Transform player;
    public float jumpInterval = 1f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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

    // Called during the Jump animation, at the point where the slime jumps in air (Jump.anim)
    public void StartJump()
    {
        Jump();
    }
}