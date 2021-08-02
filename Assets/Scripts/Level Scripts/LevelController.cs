using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PlayerController playerController;
    [HideInInspector]
    public bool hasWon = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerController.hasKey == true)
            {
                hasWon = true;
                Debug.Log("Level finished");
                Debug.Log("Reched has won");
            }
            else
            {
                Debug.Log("Find the key to move to the next level!");
                hasWon = false;
            }
        }
    }
}
