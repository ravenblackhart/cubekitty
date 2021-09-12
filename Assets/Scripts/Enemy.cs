using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
        if (other.transform.tag == "Player")
        {
            
        }
    }
}
