using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Marbles : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] private float bouyancy = 0.1f;
    
    private float posY;
    private float posX;
    private float Offset;

    private Rigidbody rigidBody;

    private void Start()
    {
        Offset = Random.Range(0.1f,0.3f);
        posY = transform.position.y;
        posX = transform.position.x;

        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       AnimateMarble();
    }

    public void Collect()
    {
        Destroy(gameObject);
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

        // transform.eulerAngles += rotateSpeed * new Vector3(0, 1, 0) * Time.deltaTime;
        // transform.position = new Vector3(posX, posY + (Mathf.Sin(Time.time) * (Offset)),0f );
    }
}
