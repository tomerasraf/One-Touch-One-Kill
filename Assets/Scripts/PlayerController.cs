using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Parameters")]
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    [Header("Player Essensial Components")]
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] BoxCollider2D playerBoxCollider;
    [SerializeField] private LayerMask groundLayerMask;

    private bool moveLeft;
    private bool moveRight;
    private Vector2 diraction;

    private void Update()
    {
        GetInputFromPlayer();
        HandleJump();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInputFromPlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

    }

    void MovePlayer()
    {
        if (moveLeft == true)
        {
            playerRb.velocity = new Vector2(-playerSpeed, playerRb.velocity.y);
        }
        else
        {
            if (moveRight == true)
            {
                playerRb.velocity = new Vector2(playerSpeed, playerRb.velocity.y);
            }
            else
            {
                // No Keys Preesed
                playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            }
        }
    }

    private bool IsGrounded()
    {
        float extraHight = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, extraHight, groundLayerMask);

        return raycastHit.collider != null;
    }

    void HandleJump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }
}


