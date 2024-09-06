using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GridBrushBase;

public class ChanMover : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float MoveSpeed;


    [SerializeField] CinemachineVirtualCamera Cam;
   



    private void Start()
    {


    }
    private void Update()
    {

        Move();
        Jump();
        Zoom();
        Dance();
        Roll();
        Changeprio();
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Dash",true);
            MoveSpeed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            animator.SetBool("Dash", false);
            MoveSpeed = 3f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
       
        

      
        animator.SetFloat("MoveSpeed", Math.Abs(z) + Math.Abs(x));

        transform.Translate(Vector3.forward * z * MoveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, x * 90f * Time.deltaTime);
        
        //Vector3 dir = new Vector3(x, 0, z);
        //if (dir == Vector3.zero)
        //{
        //    return;
        //}

       
        //transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime,Space.World);
        //transform.rotation = Quaternion.LookRotation(dir);
    }
    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
            
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            animator.SetBool("Jump", false);
        }
    }
    private void Zoom() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("Zoom", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            animator.SetBool("Zoom", false);
        }    
    }
    private void Dance() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            animator.SetTrigger("Dance1");  
        }
    }
    private void Roll() 
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Roll");
        }
    }
    private void Changeprio()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cam.Priority = 5;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cam.Priority = 15;
        }
    }
}
