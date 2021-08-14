using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameWonPanel;
    public UIController uIController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerController.hasKey == true)
            {
                PlayerPrefs.SetInt("levelReach", uIController.nextScene);
                Debug.Log("Level finished");
                gameWonPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Find the key to move to the next level!");
            }
        }
    }
}
