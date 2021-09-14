using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private GameObject playerPrefab;
    public int HealthPoints = 5;
    public int Marbles = 5;

    [Header("Movement")]
    [SerializeField] private float rollSpeed = 3f;
    [SerializeField] private float fallSpeed = 3f;
  
    #endregion

    #region Other Declarations
    
    //Public Declarations

    //Private Declarations
    private bool isMoving;
    private Marbles marbles;

    private RaycastHit Catcher;
    private RaycastHit Grounder;

    private Rigidbody rigidBody;
    
    private float timeDelay = 0.3f;
    

    #endregion

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

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

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(2))
        {
            if (playerPrefab.transform.up == Vector3.up )
            {
                Debug.Log("Mia! You ded!");
                OnAttack();
            }

            else
            {
                Debug.Log("Can't Attack");
            }
        }
        



    }

    void CheckGround()
    {
        int groundMask = 1 << 7;

        if (!Physics.Raycast(transform.position, (Vector3.down), out Grounder, 0.6f, groundMask))
        {
            rigidBody.useGravity = true;
            rigidBody.AddForce(Vector3.down*fallSpeed, ForceMode.Acceleration);
            if (transform.position.y < -1)
            {
                Destroy(playerPrefab);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
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
        
        CheckGround();

        isMoving = false;
    }
    
    void OnAttack()
    {
        int enemyMask = 1 << 6;

        if (Physics.Raycast(playerPrefab.transform.position, playerPrefab.transform.TransformDirection(Vector3.back), out Catcher, 1.5f, enemyMask))
        {
            Destroy(Catcher.transform.gameObject);
        }
    }
  
}
