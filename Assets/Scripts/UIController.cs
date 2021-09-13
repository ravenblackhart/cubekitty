using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region GUI

    [Header("HUD Components")] 
    public TextMeshProUGUI HealthCounter;
    public TextMeshProUGUI MarblesCounter;

    [Header("Menus & Buttons")] 
    [SerializeField] public Button PauseButton;
    [SerializeField] public Button ResumeButton;
    [SerializeField] public Button MainMenuButton;
    [SerializeField] public Button RestartButton;
    
    [SerializeField] public Button GOMainMenuButton;
    [SerializeField] public Button GORestartButton;

    [SerializeField] public GameObject PauseMenu;
    [SerializeField] public GameObject GameOverMenu;
    
    #endregion

    #region Other Declaration

    private PlayerController playerController;


    #endregion
    // private void Awake()
    // {
    //     GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
    //     if (objs.Length > 1)
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     
    //     DontDestroyOnLoad(gameObject);
    // }

    void Start()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        //Adding Listeners
        MainMenuButton.onClick.AddListener(MainMenu);
        PauseButton.onClick.AddListener(PauseGame);
        ResumeButton.onClick.AddListener(ResumeGame);
        RestartButton.onClick.AddListener(RestartLevel);
        GOMainMenuButton.onClick.AddListener(MainMenu);
        GORestartButton.onClick.AddListener(RestartLevel);

    }

   void Update()
    {
        HealthCounter.text = playerController.HealthPoints.ToString();
        MarblesCounter.text = playerController.Marbles.ToString();
        
        if (playerController.HealthPoints == 0)
        {
            GameOverMenu.SetActive(true);
        }


    }

   #region In-Game Menu Actions

   void PauseGame()
   {
      
       if (!PauseMenu.activeSelf)
       {
           Debug.Log("Pausing");
           PauseMenu.SetActive(true);
           Time.timeScale = 0.0f;
       }

       else if (PauseMenu.activeSelf)
       {
          ResumeGame();
       }
   }

   void ResumeGame()
   {
       Debug.Log("Resuming");
       PauseMenu.SetActive(false);
       Time.timeScale = 1.0f;
   }

   void MainMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }

   void RestartLevel()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   #endregion
    
}
