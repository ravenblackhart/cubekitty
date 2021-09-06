using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private float rollSpeed = 1f;

    

    #endregion

    #region Other Declarations
    
    //Public Declarations
    public InputAction MoveLeft;
    public InputAction MoveRight;
    public InputAction MoveForward;
    public InputAction MoveBack;
    public InputAction Attack;
    public InputAction Move;
    
    //Private Declarations
    private bool isMoving;

    #endregion

    void FixedUpdate()
    {
        if (isMoving) return;

        if (Move.triggered)
        {
            OnMove();
        }

        // if (MoveLeft.triggered) OnLeft();
        //
        // else if (MoveRight.triggered) OnRight();
        //
        // else if (MoveForward.triggered) OnForward();
        //
        // else if (MoveBack.triggered) OnBackward();
        //
        // else if (Attack.triggered) OnAttack();

        
    }

    #region Movements

    void OnMove()
    {
        
    }
    
    // void OnForward()
    // {
    //     var newAnchor = transform.position + new Vector3(0, -0.5f, 0.5f);
    //     var rotAxis = Vector3.Cross(Vector3.up, Vector3.forward);
    //     StartCoroutine(Roll(newAnchor, rotAxis ));
    // }
    //
    // void OnLeft()
    // {
    //     var newAnchor = transform.position + new Vector3(-0.5f, -0.5f, 0);
    //     var rotAxis = Vector3.Cross(Vector3.up, Vector3.left);
    //     StartCoroutine(Roll(newAnchor, rotAxis ));
    // }
    //
    // void OnRight()
    // {
    //     var newAnchor = transform.position + new Vector3(0.5f, -0.5f, 0);
    //     var rotAxis = Vector3.Cross(Vector3.up, Vector3.right);
    //     StartCoroutine(Roll(newAnchor, rotAxis ));
    // }
    //
    // void OnBackward()
    // {
    //     var newAnchor = transform.position + new Vector3(0, -0.5f, -0.5f);
    //     var rotAxis = Vector3.Cross(Vector3.up, Vector3.back);
    //     StartCoroutine(Roll(newAnchor, rotAxis ));
    // }

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
    
    #endregion


}
