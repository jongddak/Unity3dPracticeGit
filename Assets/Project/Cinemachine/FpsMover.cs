using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsMover : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] Transform camTrasform;
    [SerializeField] float Damage;
    
    [SerializeField] CinemachineVirtualCamera PlayerCam;

    private Transform Camtrans;

    private void Update()
    {
        Move();
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
}
