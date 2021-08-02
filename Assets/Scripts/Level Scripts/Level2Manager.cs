using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public LevelController levelController;
    private int currentLevel = 2;

    private void Update() {
        if(levelController.hasWon)
        {
            PlayerPrefs.SetInt("levelReached", currentLevel + 1);
        }
    }
}
