using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumble : MonoBehaviour
{
    private bool isTriggered = false;
    private ParticleSystem particle;
    [SerializeField]private GameObject tilePrefab;

    private void Awake()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        if (particle.isPlaying) particle.Pause(true);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isTriggered) isTriggered = true;
           
        
    }

    public void OnCollisionExit(Collision other)
    {
        if (isTriggered)
        {
            Destroy(tilePrefab);
            particle.Play(true);
        }

    }
}
