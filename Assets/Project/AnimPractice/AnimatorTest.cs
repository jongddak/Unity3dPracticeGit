using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        float z = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * 2f * z * Time.deltaTime);
        animator.SetFloat("Speed", z);  
    }
}
