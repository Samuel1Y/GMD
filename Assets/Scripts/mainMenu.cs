using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject loadingscreen;
    public string sceneName;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playGame()
    {
        loadingscreen.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }
    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void twitchLink()
    {
        Application.OpenURL("https://www.twitch.tv/magnoremo");
    }
}