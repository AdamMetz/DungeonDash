using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 playerDirection;
    private Rigidbody2D rb;
    private Animator animator;

    public int speed = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue inputValue) { 
        playerDirection = inputValue.Get<Vector2>();

        if (playerDirection == Vector2.zero) { 
            animator.SetBool("isMoving", false); 
        } else { 
            animator.SetBool("isMoving", true); 
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(playerDirection * speed);
        rb.MovePosition(rb.position + playerDirection * Time.fixedDeltaTime * speed);
    }
}
