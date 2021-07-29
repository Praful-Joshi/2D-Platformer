using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerController.hasKey == true)
            {
                Debug.Log("Level 1 finished");
            }
            else
            {
                Debug.Log("Find the key to move to the next level!");
            }
        }
    }
}
