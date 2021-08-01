using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject levelSelection, backButton;
    private bool hasQuit;

    private void Update() {
        if(hasQuit)
        {
            Application.Quit();
        }
    }
    
    public void PlayButton()
    {
        levelSelection.SetActive(true);
        backButton.SetActive(true);
    }

    public void QuitButton()
    {
        hasQuit = true;
    }

    public void BackButton()
    {
        levelSelection.SetActive(false);
        backButton.SetActive(false);
    }

    public void Level1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3Button()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4Button()
    {
        SceneManager.LoadScene(4);
    }
}
