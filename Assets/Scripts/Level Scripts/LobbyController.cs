using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LobbyController : MonoBehaviour
{
    public GameObject levelSelection, backButton, resetButton;

    public void PlayButton()
    {
        SFXManager.sfxInstance.Play("ButtonClick");
        levelSelection.SetActive(true);
        backButton.SetActive(true);
        resetButton.SetActive(true);
    }

    public void QuitButton()
    {
        SFXManager.sfxInstance.Play("QuitButtonClick");
        Application.Quit();
    }

    public void BackButton()
    {
        SFXManager.sfxInstance.Play("BackButtonClick");
        levelSelection.SetActive(false);
        backButton.SetActive(false);
        resetButton.SetActive(false);
    }

    public void ResetLevels()
    {
        SFXManager.sfxInstance.Play("BackButtonClick");
        PlayerPrefs.SetInt("levelReach", 1);
    }

    public void Level1Button()
    {
        SFXManager.sfxInstance.Play("StartButtonClick");
        SceneManager.LoadScene(1);
    }

    public void Level2Button()
    {
        SFXManager.sfxInstance.Play("StartButtonClick");
        SceneManager.LoadScene(2);
    }

    public void Level3Button()
    {
        SFXManager.sfxInstance.Play("StartButtonClick");
        SceneManager.LoadScene(3);
    }

    public void Level4Button()
    {
        SFXManager.sfxInstance.Play("StartButtonClick");
        SceneManager.LoadScene(4);
    }
}
