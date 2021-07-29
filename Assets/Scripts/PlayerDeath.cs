using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private PlayerController playerController;
    private Transform myTransform;
    public GameObject respawnPosition;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        myTransform = GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.health -= 50; 
            // Debug.Log("Health = " + playerController.health);
            if (playerController.health == 0)
            {
                playerController.lives -= 1;
                Respawn();
                // Debug.Log("Lives remaining = " + playerController.lives);
                playerController.health = 100;
            }
            if(playerController.lives == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }
        }
    }

    private void Respawn()
    {
        myTransform.position = respawnPosition.transform.position;
    }
}
