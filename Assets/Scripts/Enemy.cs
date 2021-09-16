using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private bool isHit = false;
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isHit)
        {
            isHit = true;
            other.gameObject.GetComponent<ParticleSystem>().Play(true);
        }
    }
}
