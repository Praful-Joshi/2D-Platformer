using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declaring Constants
    [SerializeField]
    internal float moveForce, jumpForce = 10f;

    //Declaring components
    private SpriteRenderer sr;
    private Rigidbody2D myBody;

    //Other class references
    private PlayerController playerController;
    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    internal void PlayerMovementKeyboard(float horizontal)
    {
        transform.position += new Vector3(horizontal, 0f, 0f) * Time.deltaTime * moveForce;
    }

    internal void CheckWhereToFace()
    {
        if (playerController.horizontal > 0)
            sr.flipX = false;
        else if (playerController.horizontal < 0)
            sr.flipX = true;
    }

    internal void PlayerJump()
    {
        if (playerController.isJumpPressed && playerController.isGrounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            playerController.isJumpPressed = false;
            playerController.isGrounded = false;
            playerAnimations.PlayerJump();
        }
    }
}
