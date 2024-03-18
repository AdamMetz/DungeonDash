using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 playerDirection;
    public int playerSpeed;

    // Update is called once per frame
    void Update()
    {
        getInput();
        transform.Translate(playerDirection * Time.deltaTime * playerSpeed);  
    }

    private void getInput() {
        playerDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) playerDirection += Vector2.up;
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector2.left;
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector2.down;
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector2.right;
    }
}
