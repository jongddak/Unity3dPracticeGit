using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerInput PlayerInput;

    [SerializeField] Rigidbody body;

    private void Update()
    {
        Vector2 move = PlayerInput.actions["Move"].ReadValue<Vector2>();
        Vector2 dir = new Vector3(move.x,0, move.y); 
        body.AddForce(dir*3f,ForceMode.Force);    
        // ispresed - getkey 
        // waspressedthisframe  - getkeyDown
        // WasReleasedthisFrame - 
        bool jump = PlayerInput.actions["Jump"].WasPressedThisFrame();
        if (jump) 
        {
            Debug.Log("มกวม");
            body.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

    }
}
