using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skill")]
public class Skills : ScriptableObject 
{
    public string skillname;
    public string description;  
    public float coolTime;

    public Sprite icon;

    public void Use() 
    {
        Debug.Log($"{name} : {description}");
    }
}

