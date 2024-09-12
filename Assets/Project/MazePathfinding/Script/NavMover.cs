using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask layerMask;
    private void Update()
    {
        Targeting();
    }

    private void Targeting() 
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                agent.destination = hit.point;
               // Debug.Log("Hit Position: " + hit.point);
            }
        }
    }
}
