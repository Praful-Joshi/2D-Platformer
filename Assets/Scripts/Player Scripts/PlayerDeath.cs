using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private string HURT = "Player_Hurt";
    internal bool isHurt, isDead, isHurting = false, isDying = false;
    private PlayerController playerController;
    private Transform myTransform;
    public GameObject respawnPosition;
    public UIController uIController;
    private Animator anim;
    private float hurtDelay, deathDelay;

    private PlayerAnimations playerAnimations;

    private void Update()
    {
        DeathByFalling();
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        myTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!playerController.isAttacking)
            {
                isHurt = true;
                PlayerHurt();
                playerController.health -= 50;
                if (playerController.health == 0)
                {
                    playerController.lives -= 1;
                    playerDeath();
                    playerController.health = 100;
                }
                if (playerController.lives == 0)
                {
                    playerDeath();
                    Destroy(gameObject);
                    uIController.GameOverPanel();
                }
            }
        }
    }

    public void DeathByFalling()
    {
        if (transform.position.y <= -17.5f)
        {
            if (playerController.lives != 0)
            {
                playerController.lives -= 1;
                Respawn();
                playerController.health = 100;
            }
            if (playerController.lives == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(1);
            }
        }
    }

    void playerDeath()
    {

    }

    void PlayerHurt()
    {
        if (isHurt)
        {
            isHurt = false;
            if (!isHurting)
            {
                isHurting = true;
                playerAnimations.ChangeAnimationState(HURT);
                hurtDelay = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("HurtComplete", hurtDelay);
            }
        }
    }

    void HurtComplete()
    {
        isHurting = false;
    }


    private void Respawn()
    {
        myTransform.position = respawnPosition.transform.position;
    }
}
