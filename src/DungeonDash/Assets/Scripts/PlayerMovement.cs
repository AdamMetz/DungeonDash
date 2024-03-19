using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private void OnMovement(InputValue inputValue) { 
        playerDirection = inputValue.Get<Vector2>();

        if (playerDirection == Vector2.zero) { 
            animator.SetBool("isMoving", false); 
        } else { 
            animator.SetBool("isMoving", true); 
        }

        if (playerDirection.x < 0) {
            sprite.flipX = true;
        } else if (playerDirection.x > 0) { 
            sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(playerDirection * speed);
        rb.MovePosition(rb.position + playerDirection * Time.fixedDeltaTime * speed);
    }
}
