using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//확장메서드 
public static class Extension
{
    public static void Check(this LayerMask layerMask, int layer)  // 특정 레이어마스크 n번 레이어 체크
    {
        layerMask |= 1<<layer;
    }
    public static void UnCheck(this LayerMask layerMask, int layer) // 특정 레이어마스크 n번 레이어 언체크
    {
        layerMask &= ~(1<<layer);
    }

    public static bool Contain(this LayerMask layerMask, int layer) // 특정 레이어마스크 n번 레이어 체크되어있는지 확인 
    {
        return (layerMask&(1<<layer)) != 0; 
    }
}
