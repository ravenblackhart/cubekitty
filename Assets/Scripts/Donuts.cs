using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Donuts : MonoBehaviour
{

    private PlayerController playerController;

    private bool isHit = false;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isHit && playerController.HealthPoints < 5)
        {
            isHit = true;
            playerController.HealthPoints++;
            Destroy(gameObject);

        }
    }
    
}
