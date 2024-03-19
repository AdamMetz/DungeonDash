using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 playerDirection;
    private Rigidbody2D rb;

    public int speed = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMovement(InputValue inputValue) { 
        playerDirection = inputValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(playerDirection * speed);
        rb.MovePosition(rb.position + playerDirection * Time.fixedDeltaTime * speed);
    }
}
