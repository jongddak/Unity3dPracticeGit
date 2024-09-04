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
    {   //�÷��̾� �� ����� ķ�� y�� ȸ�������� �����ͼ� �÷��̾ ȸ����Ŵ 
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
