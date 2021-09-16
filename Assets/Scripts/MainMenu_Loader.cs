using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Loader : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager gameManager;
    void Awake()
    {
        GameObject[] mgm = GameObject.FindGameObjectsWithTag("GameController");
        gameManager = GameManager.GetComponent<GameManager>();
        if (mgm.Length < 1) Instantiate(GameManager);

    }

    void Start()
    {
        int s = Random.Range(0, gameManager.Skybox.Length);
        RenderSettings.skybox = gameManager.Skybox[s];
    }
    
    void Update()
    {
        
    }
}
