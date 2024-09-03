using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    

    private void Update()
    {
        Move();
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

        transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime,Space.Self);
       // transform.rotation = Quaternion.LookRotation(dir);

       
    }
}
