using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTester : MonoBehaviour
{
    [System.Flags] // 이걸 쓰면 열거형도 레이어마스크처럼 복수선택 가능 
    enum MonsterType
    {
        Poison = 0001,
        Fire = 0010,
        Water = 0100,
        Grass = 1000,
        Electric = 00010000,

        chaos = Fire | Water 


    }
    [SerializeField] MonsterType monsterType;  // 열거형은 하나만 선택가능 
    [SerializeField] LayerMask layerMask;


    private void Start()
    {
        // 비트연산
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
            //충돌한 오브젝트가 레이어가 체크되어있으면 동작 
        }
    }

}
