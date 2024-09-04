using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;

    private Vector3 curoffset;
    private float currentX = 0f;
    private float currentY = 0f;

    //3��Ī ī�޶� 
    private void Start()
    {
        if (playerTransform == null)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            playerTransform = Player.transform;
        }
        else
        {
            Debug.Log("�÷��̾���� ");
        }
        curoffset = offset;
    }
    //private void Update()//������Ʈ���� ī�޶� ����ٴϰ� �ϸ� �������� �������ų� �÷��̾��� ��������
    //                     //���� ���Ǹ� ī�޶� ������ �ʰ� ����ٳ༭ ����ϰ� ���� �� ���� (�÷��̾ �Ⱥ��ϼ���) => lateUpdate ����ϸ� �ذ� ! 
    //{
    //    transform.position = playerTransform.position + offset;   // ����(������)��ŭ �������� �÷��̾ ī�޶� ����ٴ� 
    //    transform.LookAt(playerTransform.position); // �÷��̾ �ٶ󺸰�
    //}
    private void LateUpdate()
    {
        Look();
    }
    private void Look()
    {   // ī�޶� ���� �÷��̾� ���� �Ǿ��� => ī�޶� ������ ���� �÷��̾� ���鵵 ���ƾ���
        // ���� ������ ����ĳ���� �̿��ϸ�? 
        // �÷��̾ ���̸� ���� �÷��̾ ���ϸ鰡���� �ְ� �ٸ��� ���ϸ� �÷��̾ �� �Ҷ����� ķ�� ��������� 
        transform.position = playerTransform.position + curoffset;
        transform.LookAt(playerTransform.position);

        if (Input.GetMouseButton(1))
        {
            Debug.Log("��Ŭ�� ���� ");
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            currentX += x * 400f * Time.deltaTime;
            currentY -= y * 400f * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

            //ȸ������ �����¿� ���� 
            curoffset = rotation * offset;

            playerTransform.Rotate(Vector3.up, x * 400f * Time.deltaTime); //�÷��̾� ȸ�� 
        }
        else
        {
            Vector3 behindPosition = playerTransform.position + playerTransform.forward * offset.z + Vector3.up * offset.y; // �÷��̾� ������� 

            curoffset = behindPosition - playerTransform.position;
            transform.position = behindPosition;
            transform.LookAt(playerTransform.position);
            
        }

    }


}
