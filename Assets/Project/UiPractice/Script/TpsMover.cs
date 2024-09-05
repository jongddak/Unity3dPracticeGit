using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TpsMover : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera ZoomCam;
   
    [SerializeField] Transform PlayerTransform;

    [SerializeField] GameObject CrossHair;

    [SerializeField] PlayerModel model;


    private bool isOnZoom = false;
    private void Update()
    {
        Move();
        Zoom();
        Cursor.lockState = CursorLockMode.Locked;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isOnZoom)
            {
                Shoot();
            }
            else 
            {
                Debug.Log("¡‹ ªÛ≈¬∞° æ∆¥’¥œ¥Ÿ ");
            }
        }
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, 0, z);

        if (dir == Vector3.zero)
        {
            return;
        }

        transform.Translate(dir.normalized * 5f * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir);
        ZoomCam.gameObject.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Zoom()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isOnZoom = true;
            Debug.Log("¡‹¿Œ");
           
            
            ZoomCam.Priority = 15;

            CrossHair.SetActive(true);


        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Debug.Log("¡‹ æ∆øÙ");
        
            ZoomCam.Priority = 5;

            CrossHair.SetActive(false);
            isOnZoom = false;
        }

    }
    private void Shoot() 
    {
        if (model.curAmmo > 0)
        {

            Debug.Log("πﬂªÁ");
            model.curAmmo -= 1;

        }
        else 
        {
            Debug.Log("√—æÀ¿Ã ∫Œ¡∑«’¥œ¥Ÿ.");
        }
    }
}
