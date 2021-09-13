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
    private UIController _uiController;
    
    private Button m_pauseButton;
    private Button m_resumeButton;
    private Button m_mainmenuButton;
    private Button m_restartButton;

    private GameObject pauseMenu;
    private GameObject gameoverMenu;
    
    private void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
    }

    void Start()
    {
        m_pauseButton = _uiController.PauseButton;
        m_resumeButton = _uiController.ResumeButton;
        m_mainmenuButton = _uiController.MainMenuButton;
        m_restartButton = _uiController.RestartButton;

        pauseMenu = _uiController.PauseMenu;
        gameoverMenu = _uiController.GameOverMenu;
        
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
