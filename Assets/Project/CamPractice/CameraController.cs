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

    //3인칭 카메라 
    private void Start()
    {
        if (playerTransform == null)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            playerTransform = Player.transform;
        }
        else
        {
            Debug.Log("플레이어없음 ");
        }
        curoffset = offset;
    }
    //private void Update()//업데이트에서 카메라를 따라다니게 하면 프레임이 낮아지거나 플레이어의 움직임이
    //                     //먼저 계산되면 카메라가 한템포 늦게 따라다녀서 어색하게 보일 수 있음 (플레이어가 안보일수도) => lateUpdate 사용하면 해결 ! 
    //{
    //    transform.position = playerTransform.position + offset;   // 유격(오프셋)만큼 떨어져서 플레이어를 카메라가 따라다님 
    //    transform.LookAt(playerTransform.position); // 플레이어를 바라보게
    //}
    private void LateUpdate()
    {
        Look();
    }
    private void Look()
    {   // 카메라 앞이 플레이어 앞이 되야함 => 카메라 방향이 돌때 플레이어 정면도 돌아야함
        // 벽에 막힐때 레이캐스팅 이용하면? 
        // 플레이어에 레이를 쏴서 플레이어가 힛하면가만히 있고 다른게 힛하면 플레이어가 힛 할때까지 캠이 가까워지게 
        transform.position = playerTransform.position + curoffset;
        transform.LookAt(playerTransform.position);

        if (Input.GetMouseButton(1))
        {
            Debug.Log("우클릭 눌림 ");
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            currentX += x * 400f * Time.deltaTime;
            currentY -= y * 400f * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

            //회전값을 오프셋에 저장 
            curoffset = rotation * offset;

            playerTransform.Rotate(Vector3.up, x * 400f * Time.deltaTime); //플레이어 회전 
        }
        else
        {
            Vector3 behindPosition = playerTransform.position + playerTransform.forward * offset.z + Vector3.up * offset.y; // 플레이어 뒤통수로 

            curoffset = behindPosition - playerTransform.position;
            transform.position = behindPosition;
            transform.LookAt(playerTransform.position);
            
        }

    }


}
