using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private GameObject playerPrefab;
    public int HealthPoints = 5;
    public int Marbles = 5;

    [Header("Movement")]
    [SerializeField] private float rollSpeed = 1f;
    
    
    
    

    

    #endregion

    #region Other Declarations
    
    //Public Declarations

    //Private Declarations
    private bool isMoving;
    private bool isAttacking = false;
    private Marbles marbles;

    private RaycastHit Catcher;

    private float timeDelay ;
    

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
            if (transform.rotation.x == 0 && transform.rotation.z == 0)
            {
                
                Debug.Log("mia!");
            }

            else
            {
                
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(2))
        {
            if (playerPrefab.transform.up == Vector3.up )
            {
                StartCoroutine(OnAttack());
            }

            else
            {
                Debug.Log("Can't Attack");
                isAttacking = false;
            }
        }

        if (HealthPoints == 0)
        {
            Destroy(playerPrefab);
        }

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
    
    IEnumerator OnAttack()
    {
        isAttacking = true;
        int layerMask = 1 << 6;

        if (Physics.Raycast(playerPrefab.transform.position, playerPrefab.transform.TransformDirection(Vector3.back), out Catcher, 1f, layerMask))
        {
            Destroy(Catcher.transform.gameObject);
        }
        yield return new WaitForSeconds(0.3f);
        isAttacking = false;
    }

    IEnumerator OnDead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(playerPrefab);
    }

    

}
