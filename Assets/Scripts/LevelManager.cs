using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

    public int marblesCollected;
    public int donutsCollected;
    public int enemiesScared;

    void Start()
    {
        GameObject[] marbles = GameObject.FindGameObjectsWithTag("Marble");
        GameObject[] donuts = GameObject.FindGameObjectsWithTag("Donut");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        uiManager = GameObject.Find("UIController").GetComponent<UIManager>();
        
        
        Debug.Log($"{marbles.Length} marbles & {donuts.Length} donuts found. There were {enemies.Length} silly doggos ");
    }

    // Update is called once per frame
    void Update()
    {
        CheckGoals();
        CheckLevelCleared();
    }

    void CheckGoals()
    {
        int marblesLeft = MarblesToCollect - marblesCollected;
        int donutsLeft = DonutsToCollect - donutsCollected;
        int enemiesLeft = EnemiesToScare - enemiesScared;

        if (marblesLeft <= 0 && donutsLeft <= 0 && enemiesLeft <= 0) GoalAchieved = true;
        else
        {
            Debug.Log($"{marblesLeft} marbles, {donutsLeft} donuts & {enemiesLeft} doggos to go!");
        }
    }
    public void CheckLevelCleared()
    {
        if (GoalAchieved && playerController.isFinished)
        {
            uiManager.NextLevelMenu.enabled = true;
        }
    }
}
