using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HororFpsMover : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] Transform Player;


    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //float x1 = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(x, 0, z);

        if (dir == Vector3.zero)
        {
            return;
        }

        transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime, Space.Self);
        
    }
}
