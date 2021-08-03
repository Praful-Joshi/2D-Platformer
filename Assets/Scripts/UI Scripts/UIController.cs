using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject gameOverPanel;
    internal int nextScene;
    [SerializeField]
    private int currentScene;

    private void Awake() {
        NextScene(currentScene);
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

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        gameOverPanel.SetActive(false);
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
