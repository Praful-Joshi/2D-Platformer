using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject heart1, heart2, heart3;
    public TextMeshProUGUI healthText;

    private void Update()
    {
        ManageHearts();
        ManageHealth();
    }

    private void ManageHearts()
    {
        if(playerController.lives == 2)
        {
            heart3.SetActive(false);
        }
        if(playerController.lives == 1)
        {
            heart2.SetActive(false);
        }
        if(playerController.lives == 0)
        {
            heart1.SetActive(false);
        }
    }

    private void ManageHealth()
    {
        healthText.text = "Health: " + playerController.health;  
    }

}
