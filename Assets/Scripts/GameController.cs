using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region GUI
    public int HealthPoints = 5;
    public int Marbles = 5;

    [Header("HUD Components")] 
    public TextMeshProUGUI HealthCounter;
    public TextMeshProUGUI MarblesCounter;

    [Header("Menus & Buttons")] 
    [SerializeField] public Button PauseButton;
    [SerializeField] public Button ResumeButton;
    [SerializeField] public Button RestartButton;
    [SerializeField] public Button MainMenuButton;
    
    [SerializeField] public GameObject PauseMenu;
    [SerializeField] public GameObject GameOverMenu;
    
    #endregion
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //Adding Listeners
        MainMenuButton.onClick.AddListener(MainMenu);
        PauseButton.onClick.AddListener(PauseGame);
        ResumeButton.onClick.AddListener(ResumeGame);
        RestartButton.onClick.AddListener(RestartLevel);

    }

   void Update()
    {
        HealthCounter.text = HealthPoints.ToString();
        MarblesCounter.text = Marbles.ToString();

        if (HealthPoints == 0)
        {
            Debug.Log("Oh no am ded!");
        }


    }

   #region In-Game Menu Actions

   void PauseGame()
   {
       if (PauseMenu != isActiveAndEnabled)
       {
           PauseMenu.SetActive(true);
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
       PauseMenu.SetActive(false);
   }

   void MainMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }

   void RestartLevel()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   #endregion
    
}
