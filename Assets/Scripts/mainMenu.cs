using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel, loadingscreen, controlsPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        loadingscreen.SetActive(true);
        SceneManager.LoadScene("GameScene");
    }
    public void OpenControls()
    {
        mainPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
    public void CloseControls()
    {
        controlsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}