using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTester : MonoBehaviour
{
    [System.Flags] // �̰� ���� �������� ���̾��ũó�� �������� ���� 
    enum MonsterType
    {
        Poison = 0001,
        Fire = 0010,
        Water = 0100,
        Grass = 1000,
        Electric = 00010000,

        chaos = Fire | Water 


    }
    [SerializeField] MonsterType monsterType;  // �������� �ϳ��� ���ð��� 
    [SerializeField] LayerMask layerMask;


    private void Start()
    {
        // ��Ʈ����
        Debug.Log(layerMask.value);

        layerMask = 1 << 0;

        Debug.Log(layerMask.value);

        layerMask = 1 << 1;

        Debug.Log(layerMask.value);

        layerMask = 1 << 3;

        Debug.Log(layerMask.value);

        layerMask.Check(7);
        layerMask.UnCheck(7);
        Debug.Log(layerMask.Contain(7));
        layerMask.Contain(7);

        Debug.Log(layerMask.value);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask.Contain(collision.gameObject.layer))
        {
            //�浹�� ������Ʈ�� ���̾ üũ�Ǿ������� ���� 
        }
    }

}
