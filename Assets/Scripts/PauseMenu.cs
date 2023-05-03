using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused;
    [HideInInspector]
    public GameObject player;
    private SC_FPSController controller;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        controller = player.GetComponent<SC_FPSController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
                
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        paused = true;
        controller.canMove = false;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        paused = false;
        controller.canMove = true;
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
