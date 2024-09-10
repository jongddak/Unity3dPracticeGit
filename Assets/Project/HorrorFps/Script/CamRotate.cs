using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
   [SerializeField] Transform playerTransForm;
   // [SerializeField] Transform cameraTransForm;



    private void Update()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        float x = Input.GetAxis("Mouse X");
        playerTransForm.Rotate(Vector3.up, x* 300f * Time.deltaTime);
       
    }
}
