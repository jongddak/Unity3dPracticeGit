using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quest/NormalQuest",fileName ="Quest")]  //프로젝트창에서 우클릭하면 나오는 create에 quest를 추가
public class Quest : ScriptableObject //: MonoBehaviour  GameObject 가 수행할수 있는 기능을 상속 받음 
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
