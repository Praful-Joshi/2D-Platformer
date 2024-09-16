using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject gameOverPanel, pauseMenuPanel;
    public static bool isGamePaused = false;
    internal int nextScene;
    [SerializeField]
    private int currentScene;

    private void Awake()
    {
        NextScene(currentScene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeButton();
            }
            else
            {
                Pause();
            }
        }
    }

    public int NextScene(int currentScene)
    {
        nextScene = currentScene + 1;
        return nextScene;
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ResumeButton()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    } 

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NextLevelButton()
    {
        //code
        SceneManager.LoadScene(nextScene);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
