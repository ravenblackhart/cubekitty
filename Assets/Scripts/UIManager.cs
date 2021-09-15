using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    //Inspector Access
    [Header("HUD Components")] 
    public TextMeshProUGUI HealthCounter;
    public TextMeshProUGUI MarblesCounter;

    [Header("Menus & Displays")] 
    [SerializeField] public Canvas HUD;
    [SerializeField] public Canvas PauseMenu;
    [SerializeField] public Canvas NextLevelMenu;

    //Other Declarations
    private PlayerController playerController;

    
    void Start()
    {
        Time.timeScale = 1.0f;
        PauseMenu.enabled = false;
        NextLevelMenu.enabled = false;
        HUD.enabled = true;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

   void Update()
    {
        HealthCounter.text = playerController.HealthPoints.ToString();
        MarblesCounter.text = playerController.Marbles.ToString();
        
        if (playerController.HealthPoints == 0)
        {
            NextLevelMenu.enabled = true;
        }
    }

   #region In-Game Menu Actions

   public void PauseGame()
   {
       if (!PauseMenu.enabled)
       {
           Debug.Log("Pausing");
           PauseMenu.enabled = true;
           Time.timeScale = 0.0f;
       }

       else if (PauseMenu.enabled)
       {
           Debug.Log("Resuming");
          ResumeGame();
       }
   }

    public void ResumeGame()
   {
       PauseMenu.enabled = false;
       Time.timeScale = 1.0f;
   }

   public void MainMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }

   public void RestartLevel()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void NextLevel()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   #endregion
    
}