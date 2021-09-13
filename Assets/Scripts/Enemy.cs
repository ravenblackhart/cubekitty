using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rigidBody;
    private UIController _uiController;

    private bool isHit = false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        _uiController = GameObject.Find("GameController").GetComponent<UIController>();
    }
    
    void FixedUpdate()
    {
        EnemyPatrol();
    }

    void EnemyPatrol()
    {
        if (transform.position.y <=0.1)
        {
            rigidBody.AddForce(new Vector3(0f,0.3f, 0f));
        }

        else
        {
            rigidBody.AddForce(new Vector3(0f,-0.3f, 0f));
        }
        
        for (int x = 0; x < 5; x++)
        {
          
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isHit)
        {
            isHit = true;
            StartCoroutine(Attacking());

        }

        else
        {
            StopCoroutine(Attacking());
        }
        
        
    }

    IEnumerator Attacking()
    {
        _uiController.HealthPoints--;
        yield return new WaitForSeconds(0.3f);
        isHit = false;
    }
}
