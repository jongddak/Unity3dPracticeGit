using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    [SerializeField] GameObject MiniMap;

    private void Start()
    {
        MiniMap.SetActive(false);
    }
    private void Update()
    {
        MiniMapOn();
    }
    private void MiniMapOn() 
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("�̴ϸ� ��");
            MiniMap.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Debug.Log("�̴ϸ� ����");
            MiniMap.SetActive(false);
        }
    }
}
