using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FpsMover : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] Transform camTrasform;
    [SerializeField] float Damage;
    
    [SerializeField] CinemachineVirtualCamera PlayerCam;

    [SerializeField] GameObject CrossHair;
    [SerializeField] GameObject CrossZoom;


    private Transform Camtrans;
    private void Start()
    {
        PlayerCam.m_Lens.FieldOfView = 103f;
        CrossHair.SetActive(true);
        CrossZoom.SetActive(false);
    }

    private void Update()
    {
        Move();
        Zoom();
        Cursor.lockState = CursorLockMode.Locked;
    }



    private void Move()
    {   //플레이어 용 버츄얼 캠의 y축 회전각도를 가져와서 플레이어를 회전시킴 
        Camtrans = PlayerCam.VirtualCameraGameObject.transform;
        transform.eulerAngles = new Vector3(0, Camtrans.eulerAngles.y, 0);
       



        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, 0, z);

        if (dir == Vector3.zero)
        {
            return;
        }

        transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime, Space.Self);
    }
    private void Zoom() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
            Debug.Log("줌인");
           
            PlayerCam.m_Lens.FieldOfView = Mathf.Lerp(PlayerCam.m_Lens.FieldOfView, 20f,1f);
            
            CrossHair.SetActive(false);
            CrossZoom.SetActive(true);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Debug.Log("줌 아웃");
            PlayerCam.m_Lens.FieldOfView = Mathf.Lerp(PlayerCam.m_Lens.FieldOfView, 103f,1f);
            CrossZoom.SetActive(false);
            CrossHair.SetActive(true);
            
        }
    }

}
