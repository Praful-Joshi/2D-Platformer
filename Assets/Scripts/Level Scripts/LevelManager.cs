using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    private void Update()
    {
        int levelReach = PlayerPrefs.GetInt("levelReach", 1);

        for (var i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReach)
            {
                levelButtons[i].interactable = false;
            }

        }
    }
}
