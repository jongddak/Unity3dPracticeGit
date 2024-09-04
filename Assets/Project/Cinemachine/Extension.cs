using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ȯ��޼��� 
public static class Extension
{
    public static void Check(this LayerMask layerMask, int layer)  // Ư�� ���̾��ũ n�� ���̾� üũ
    {
        layerMask |= 1<<layer;
    }
    public static void UnCheck(this LayerMask layerMask, int layer) // Ư�� ���̾��ũ n�� ���̾� ��üũ
    {
        layerMask &= ~(1<<layer);
    }

    public static bool Contain(this LayerMask layerMask, int layer) // Ư�� ���̾��ũ n�� ���̾� üũ�Ǿ��ִ��� Ȯ�� 
    {
        return (layerMask&(1<<layer)) != 0; 
    }
}
