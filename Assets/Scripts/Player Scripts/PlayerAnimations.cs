using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //Other class references
    private PlayerController playerController;
    private PlayerMovement playerMovement;

    //Declaring components
    private Animator anim;

    //Declaring variables
    private string currentState;
    private float attackDelay;

    //Declaring constants
    private string IDLE = "Player_Idle", WALK = "Player_Walk", RUN = "Player_Run", CROUCH = "Player_Crouch",
                   JUMP = "Player_Jump", MELEE = "Player_Melee_Attack";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    internal void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }

    internal void PlayerWalk()
    {
        if (playerController.isGrounded && !playerController.isCrouch && !playerController.isAttacking)
        {
            if (playerController.horizontal == 0)
            {
                ChangeAnimationState(IDLE);
            }
            else if (playerMovement.moveForce == 4f)
            {
                ChangeAnimationState(WALK);
            }
        }
    }

    internal void PlayerRun()
    {
        if (playerController.isGrounded && !playerController.isCrouch && !playerController.isAttacking)
        {
            if (playerController.horizontal == 0)
            {
                ChangeAnimationState(IDLE);
            }
            else if (playerController.horizontal != 0 && playerController.isRunning && playerMovement.moveForce == 8f)
            {
                ChangeAnimationState(RUN);
            }
        }
    }

    internal void PlayerCrouch()
    {
        if (playerController.isCrouch && playerController.isGrounded)
        {
            ChangeAnimationState(CROUCH);
        }
    }

    internal void PlayerJump()
    {
        ChangeAnimationState(JUMP);
    }

    internal void PlayerMeleeAttack()
    {
        if (playerController.isAttackPressed)
        {
            playerController.isAttackPressed = false;
            if (!playerController.isAttacking)
            {
                playerController.isAttacking = true;
                //attack code
                FindObjectOfType<SFXManager>().Play("PlayerAttack"); //Attack sound
                ChangeAnimationState(MELEE);
                attackDelay = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("AttackComplete", attackDelay);
            }
        }
    }

    void AttackComplete()
    {
        playerController.isAttacking = false;
    }
}
