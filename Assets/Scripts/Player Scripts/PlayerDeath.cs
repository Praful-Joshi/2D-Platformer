using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private string HURT = "Player_Hurt", DEAD = "Player_Dead";
    internal bool isHurt, isDead;
    private PlayerController playerController;
    private Transform myTransform;
    public GameObject respawnPosition;
    public UIController uIController;
    private Animator anim;
    private float hurtDelay, deathDelay;

    private void Update()
    {
        DeathByFalling();
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        myTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.health -= 20;

            isHurt = true;
            PlayerHurt();
            hurtDelay = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("HurtComplete", hurtDelay);

            if (playerController.health == 0)
            {
                playerController.lives -= 1;

                isDead = true;
                PlayerDead();
                deathDelay = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("DeathComplete", deathDelay);
                
                Respawn();
                playerController.health = 100;
            }
            if (playerController.lives == 0)
            {
                isDead = true;
                PlayerDead();
                deathDelay = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("DeathComplete", deathDelay);

                Destroy(gameObject);
                uIController.GameOverPanel();
            }
        }
    }

    public void DeathByFalling()
    {
        if (transform.position.y <= -12f)
        {
            isDead = true;
            PlayerDead();
            deathDelay = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("DeathComplete", deathDelay);

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

    internal void PlayerHurt()
    {
        if (isHurt)
        {
            playerController.ChangeAnimationState(HURT);
        }
    }

    internal void PlayerDead()
    {
        if (isDead)
        {
            playerController.ChangeAnimationState(DEAD);
        }
    }

    void DeathComplete()
    {
        isDead = false;
    }

    void HurtComplete()
    {
        isHurt = false;
    }

    private void Respawn()
    {
        myTransform.position = respawnPosition.transform.position;
    }
}
