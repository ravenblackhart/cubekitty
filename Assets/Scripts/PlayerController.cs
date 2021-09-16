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
  
    #endregion

    #region Other Declarations
    
    //Public Declarations
    public bool isFinished = false;

    //Private Declarations
    private bool isMoving;
    private Marbles marbles;
    private UIManager uiManager;
    private LevelManager levelManager;

    private RaycastHit Catcher;
    private RaycastHit Grounder;

    private Rigidbody rigidBody;
    private ParticleSystem particle;

    private float restartDelay = 25f;



    #endregion

    private void Awake()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        if (particle.isPlaying) particle.Pause(true);
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        uiManager = GameObject.Find("UIController").GetComponent<UIManager>();
    }

    void Update()
    {
        if(particle.isPlaying) Destroy(playerPrefab);
        if (isMoving) return;
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) OnMove(Vector3.forward);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) OnMove(Vector3.back);
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) OnMove(Vector3.right);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) OnMove(Vector3.left);

        
        void OnMove(Vector3 moveDirection)
        {
            if (uiManager.NextLevelMenu.enabled) return;
            
            var newAnchor = transform.position + (Vector3.down + moveDirection) * 0.5f;
            var rotAxis = Vector3.Cross(Vector3.up, moveDirection);
            StartCoroutine(Roll(newAnchor, rotAxis ));
        }
        
        CheckGround();

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(2))
        {
            if (playerPrefab.transform.up == Vector3.up )
            {
                OnAttack();
            }

        }

        if (playerPrefab == null)
        {
            restartDelay -= 1f;
            if (restartDelay < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void CheckGround()
    {
        int groundMask = 1 << 7;

        if (!Physics.Raycast(transform.position, (Vector3.down), out Grounder, 0.6f, groundMask))
        {
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
            if (transform.position.y < -1) particle.Play(true);
        }
        
        else if (Physics.Raycast(transform.position, (Vector3.down), out Grounder, 0.6f, groundMask) && 
                 Grounder.transform.tag == "Finish") 
            isFinished = true;
        
        

        else
        {
            rigidBody.isKinematic = true;
            rigidBody.useGravity = false;
            isFinished = false;
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
    
    void OnAttack()
    {
        int enemyMask = 1 << 6;

        if (Physics.Raycast(playerPrefab.transform.position, playerPrefab.transform.TransformDirection(Vector3.back), out Catcher, 1.5f, enemyMask))
        {
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            levelManager.enemiesScared++;
            
            Destroy(Catcher.transform.gameObject);
        }
    }
  
}
