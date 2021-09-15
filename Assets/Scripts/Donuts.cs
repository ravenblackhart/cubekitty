using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Donuts : MonoBehaviour
{

    private PlayerController playerController;
    private LevelManager levelManager;

    private bool isHit = false;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isHit && playerController.HealthPoints < 5)
        {
            isHit = true;
            playerController.HealthPoints++;
            levelManager.donutsCollected++;
            Destroy(gameObject);

        }
    }
    
}
