using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class InGameMenu : MonoBehaviour
{
    private GameController gameController;
    
    private Button m_pauseButton;
    private Button m_resumeButton;
    private Button m_mainmenuButton;
    private Button m_restartButton;

    private GameObject pauseMenu;
    private GameObject gameoverMenu;
    
    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Start()
    {
        m_pauseButton = gameController.PauseButton;
        m_resumeButton = gameController.ResumeButton;
        m_mainmenuButton = gameController.MainMenuButton;
        m_restartButton = gameController.RestartButton;

        pauseMenu = gameController.PauseMenu;
        gameoverMenu = gameController.GameOverMenu;
        
        //Adding Listeners
        m_mainmenuButton.onClick.AddListener(MainMenu);
        m_pauseButton.onClick.AddListener(PauseGame);
        m_resumeButton.onClick.AddListener(ResumeGame);
        m_restartButton.onClick.AddListener(RestartLevel);
    }

    private void Update()
    {


    }

    void PauseGame()
    {
        if (pauseMenu != isActiveAndEnabled)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else
        {
            ResumeGame();
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
