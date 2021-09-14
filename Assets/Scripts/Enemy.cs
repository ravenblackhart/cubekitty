using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private bool isHit = false;
    private float timeDelay = 0.3f;
    

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isHit)
        {
            isHit = true;
            timeDelay -= Time.deltaTime;
            if (timeDelay < 0)
            {
                Destroy(other.gameObject);
                
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

        }
    }
}
