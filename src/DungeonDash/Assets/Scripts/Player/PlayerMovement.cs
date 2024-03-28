using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 playerDirection;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    public int speed = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMovement(InputValue inputValue)
    {
        playerDirection = inputValue.Get<Vector2>();

        UpdatePlayerMovementAnimation();
        UpdatePlayerSpriteDirection();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerDirection * Time.fixedDeltaTime * speed);
    }

    private void UpdatePlayerMovementAnimation() {
        bool isMoving = playerDirection != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
    }
    private void UpdatePlayerSpriteDirection()
    {
        if (playerDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else if (playerDirection.x > 0)
        {
            sprite.flipX = false;
        }
    }
}