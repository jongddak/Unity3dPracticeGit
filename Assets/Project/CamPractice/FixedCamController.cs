using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FixedCamController : MonoBehaviour
{
    [SerializeField] float xAngle;
    [SerializeField] float YAngle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Rotate() 
    {
        xAngle -= Input.GetAxis("Mouse Y") *400f;
        YAngle -= Input.GetAxis("Mouse X") * 400f;
    }
}
