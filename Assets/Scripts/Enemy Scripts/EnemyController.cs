using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private string SPITTER_DEATH = "Spitter_Death";

    private float enemyDeathDelay;

    internal string currentState;

    internal Animator anim;
    private BoxCollider2D boxCollider;

    public PlayerController playerController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerController.isAttacking)
            {
                ChangeAnimationState(SPITTER_DEATH);
                enemyDeathDelay = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("DestroyEnemy", enemyDeathDelay);
            }
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    internal void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }

    void ColliderDisable()
    {
        boxCollider.enabled = false;
    }
}
