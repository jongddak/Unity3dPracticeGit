using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineTest : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineVirtualCamera bossCam;


    
    private void Start()
    {   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerCam.Priority = 11;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            playerCam.Priority = 9;
        }
    }
}
