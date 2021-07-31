using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // private string HURT = "Hurt", DEAD = "Dead";
    private PlayerController playerController;
    private Transform myTransform;
    public GameObject respawnPosition;
    public UIController uIController;

    private void Update() {
        DeathByFalling();
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        myTransform = GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.health -= 25;

            // Debug.Log("Health = " + playerController.health);
            if (playerController.health == 0)
            {
                playerController.lives -= 1;
                Respawn();
                playerController.health = 100;
            }
            if(playerController.lives == 0)
            {
                Destroy(gameObject);
                uIController.GameOverPanel();
            }
        }
    }

    public void DeathByFalling()
    {
        if (transform.position.y <= -12f)
        {   
            if(playerController.lives != 0)
            {
                playerController.lives -= 1;
                Respawn();
                playerController.health = 100;
            }
            if(playerController.lives == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(1);
            }
        }
    }

    private void Respawn()
    {
        myTransform.position = respawnPosition.transform.position;
    }
}
