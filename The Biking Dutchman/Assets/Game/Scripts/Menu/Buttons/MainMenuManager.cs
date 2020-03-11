using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsPanel;

    void Start()
    {
        optionsPanel.SetActive(false);
    }

    // Executes when 'Play' clicked
    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene("PlayScene");
    }

    // Executes when 'Options' clicked
    public void ShowOptions()
    {
        Debug.Log("Show Options");
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }

    // Executes when 'Quit' clicked
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
