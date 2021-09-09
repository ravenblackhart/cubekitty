using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marbles : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 100;
    
    private float posY;
    private float posX;
    private float Offset;
    
    void Start()
    {
        Offset = Random.Range(0.1f,0.5f);
        posY = transform.position.y;
        posX = transform.position.x;
    }
    
    void Update()
    {
       AnimateMarble();
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
    
    void AnimateMarble()
    {
        transform.eulerAngles += rotateSpeed * new Vector3(0, 1, 0) * Time.deltaTime;
        transform.position = new Vector3(posX, posY + (Mathf.Sin(Time.time) * (Offset)),0f );
    }
}
