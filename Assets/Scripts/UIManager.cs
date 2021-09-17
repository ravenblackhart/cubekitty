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
    public TextMeshProUGUI ObjectivesText;

    [Header("Menus & Displays")] 
    [SerializeField] public Canvas HUD;
    [SerializeField] public Canvas PauseMenu;
    [SerializeField] public Canvas NextLevelMenu;

    [Header("Positioning")] 
    [SerializeField] private float xOffset; 
    [SerializeField] private float yOffset; 

    //Other Declarations

    void Start()
    {
        Time.timeScale = 1.0f;
        PauseMenu.enabled = false;
        NextLevelMenu.enabled = false;
        HUD.enabled = true;
    }

    #region In-Game Menu Actions

   public void PauseGame()
   {
       if (!PauseMenu.enabled && !NextLevelMenu.enabled)
       {
           PauseMenu.enabled = true;
           Time.timeScale = 0.0f;
       }

       else if (PauseMenu.enabled) ResumeGame();
       
   }

    public void ResumeGame()
   {
       PauseMenu.enabled = false;
       Time.timeScale = 1.0f;
   }

   public void MainMenu() => SceneManager.LoadScene("0_MainMenu");
   public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

   #endregion
    
}
