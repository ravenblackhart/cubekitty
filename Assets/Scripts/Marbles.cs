using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Marbles : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] private float bouyancy = 0.1f;

    private float Offset;

    private Rigidbody rigidBody;
    private PlayerController playerController;
    private LevelManager levelManager;

    private bool isHit = false;

    private void Start()
    {
        Offset = Random.Range(0.1f,0.3f);
        rigidBody = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void FixedUpdate()
    {
       AnimateMarble();
    }

    
    void AnimateMarble()
    {
        rigidBody.AddTorque(0,rotateSpeed,0, ForceMode.Impulse);
        
        if (transform.position.y <=Offset)
        {
            rigidBody.AddForce(new Vector3(0f,bouyancy, 0f));
        }

        else
        {
            rigidBody.AddForce(new Vector3(0f,-bouyancy, 0f));
        }

    }
    
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && !isHit)
        {
            isHit = true; 
            StartCoroutine(Collect());
        }
    }

    public IEnumerator Collect()
    {
        playerController.Marbles++;
        levelManager.marblesCollected++;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
