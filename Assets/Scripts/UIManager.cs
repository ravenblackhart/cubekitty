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
    [SerializeField] public TextMeshProUGUI AttackVox;

    [Header("Positioning")] 
    [SerializeField] private float xOffset; 
    [SerializeField] private float yOffset; 

    //Other Declarations
    private PlayerController playerController;
    private Transform anchorRef;
    private Vector2 anchorPos;
    private RectTransform HUDRect;
    private RectTransform AttackVoxRect;

    
    void Start()
    {
        Time.timeScale = 1.0f;
        PauseMenu.enabled = false;
        NextLevelMenu.enabled = false;
        HUD.enabled = true;
        AttackVox.enabled = false;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anchorRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        HUDRect = HUD.GetComponent<RectTransform>();
        AttackVoxRect = AttackVox.GetComponent<RectTransform>();

    }

   void Update()
    {
        HealthCounter.text = playerController.HealthPoints.ToString();
        MarblesCounter.text = playerController.Marbles.ToString();

       CharUI();



    }

   #region CharacterUI

   void CharUI()
   {
       Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, anchorRef.position);
       anchorPos = new Vector2(screenPoint.x - xOffset , screenPoint.y - yOffset);
       AttackVox.transform.position = anchorPos;
   }

   #endregion

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
