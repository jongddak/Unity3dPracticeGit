using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quest/NormalQuest",fileName ="Quest")]  //������Ʈâ���� ��Ŭ���ϸ� ������ create�� quest�� �߰�
public class Quest : ScriptableObject //: MonoBehaviour  GameObject �� �����Ҽ� �ִ� ����� ��� ���� 
{
    public string title;
    [TextArea(3,5)]
    public string description;

    public int exp;
    public int gold;

    public GameObject[] Rewards;
    public Color iconColor;
    public Sprite icon;

}
