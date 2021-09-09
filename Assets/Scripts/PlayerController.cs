using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private float rollSpeed = 1f;

    

    #endregion

    #region Other Declarations
    
    //Public Declarations

    //Private Declarations
    private bool isMoving;
    private bool onCollectMarble;

    #endregion
    
    void FixedUpdate()
    {
        if (isMoving) return;
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) OnMove(Vector3.left);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) OnMove(Vector3.right);
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) OnMove(Vector3.forward);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) OnMove(Vector3.back);

        
        void OnMove(Vector3 moveDirection)
        {
            var newAnchor = transform.position + (Vector3.down + moveDirection) * 0.5f;
            var rotAxis = Vector3.Cross(Vector3.up, moveDirection);
            StartCoroutine(Roll(newAnchor, rotAxis ));
        }

        //else if (Attack.triggered) OnAttack();

    }

    void OnAttack()
    {
        
    }

    IEnumerator Roll(Vector3 newAnchor, Vector3 rotAxis)
    {
        isMoving = true;
        for (int i = 0; i < (90/rollSpeed); i++)
        {
            transform.RotateAround(newAnchor,rotAxis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
        
    }

    #region Marbles

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Marble")
        {
            Destroy(other.gameObject);
        }
    }

    #endregion

}
