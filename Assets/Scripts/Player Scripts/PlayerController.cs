using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    //Declaring Constants
    private string GROUND_TAG = "Ground";
    public int health = 100, lives = 2;

    //Declaring Variables
    internal float horizontal;
    internal bool isGrounded, isJumpPressed, isRunning, isCrouch, isAttackPressed, isAttacking = false, hasKey = false;

    //Other class references
    private PlayerAnimations playerAnimations;
    private PlayerMovement playerMovement;
    public TMPController tMPController;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            playerMovement.moveForce = 8f;
            playerMovement.jumpForce = 10f;
        }
        else
        {
            isRunning = false;
            playerMovement.moveForce = 4f;
            playerMovement.jumpForce = 8f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !UIController.isGamePaused)
        {
            isAttackPressed = true;
        }

        if (Input.GetKey(KeyCode.C))
        {
            isCrouch = true;
        }
        else
        {
            isCrouch = false;
        }

        if (!isCrouch && !isAttacking)
        {
            playerMovement.PlayerMovementKeyboard(horizontal);
        }
    }

    private void FixedUpdate()
    {
        playerMovement.PlayerJump();
        playerAnimations.PlayerWalk();
        playerAnimations.PlayerRun();
        playerAnimations.PlayerCrouch();
        playerAnimations.PlayerMeleeAttack();
    }

    private void LateUpdate()
    {
        playerMovement.CheckWhereToFace();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }

    // Interactable functions
    public void PickUpKey()
    {
        hasKey = true;
        StartCoroutine(tMPController.KeyReceive());
    }

}
