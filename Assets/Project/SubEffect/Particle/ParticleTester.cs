using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTester : MonoBehaviour
{
    [SerializeField] ParticleSystem vfx;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            vfx.Play();
        }
    }
}
