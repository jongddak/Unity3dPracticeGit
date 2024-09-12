using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Monster", fileName = "Monster")]
public class Monster : ScriptableObject
{
    public GameObject monsterPrefab;
    

    public int atk;
    public int hp;
    public int speed;
    public int def;
}
