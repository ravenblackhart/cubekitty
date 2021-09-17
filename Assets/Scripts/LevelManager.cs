using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Header("Level Goals")] 
    [SerializeField] private int MarblesToCollect;
    [SerializeField] private int DonutsToCollect;
    [SerializeField] private int EnemiesToScare;

    [Header("Level GUI")] 
    [SerializeField] private TextMeshProUGUI Marbles;
    [SerializeField] private TextMeshProUGUI Donuts;
    [SerializeField] private TextMeshProUGUI Enemies;

    public bool GoalAchieved = false;
    private PlayerController playerController;
    private UIManager uiManager;
    private GameManager gameManager;

    public int marblesCollected;
    public int donutsCollected;
    public int enemiesScared;

    private int marblesLeft;
    private int donutsLeft;
    private int enemiesLeft;
    

    private void Awake()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        uiManager = GameObject.Find("UIController").GetComponent<UIManager>();
    }

    void Start()
    {
        int s = Random.Range(0, gameManager.Skybox.Length);
        RenderSettings.skybox = gameManager.Skybox[s];
        
        GameObject[] marbles = GameObject.FindGameObjectsWithTag("Marble");
        GameObject[] donuts = GameObject.FindGameObjectsWithTag("Donut");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        uiManager.ObjectivesText.text = $"Collect {MarblesToCollect} Marbles, Scare {EnemiesToScare} Enemies";
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGoals();
        CheckLevelCleared();
    }

    void CheckGoals()
    {
        marblesLeft = MarblesToCollect - marblesCollected;
        donutsLeft = DonutsToCollect - donutsCollected;
        enemiesLeft = EnemiesToScare - enemiesScared;

        if (marblesLeft <= 0 && donutsLeft <= 0 && enemiesLeft <= 0)
        {
            GoalAchieved = true;
            uiManager.ObjectivesText.text = $"Get to the Goal";
        }
        
        else uiManager.ObjectivesText.text = $"Collect {marblesLeft} more Marbles, Scare {enemiesLeft} more Enemies";
        
    }
    public void CheckLevelCleared()
    {
        if ((SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().name == "0_MainMenu")
            && playerController.isFinished) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        else if (GoalAchieved && playerController.isFinished)
        {
            uiManager.NextLevelMenu.enabled = true;
        }
    }
    
    
}
