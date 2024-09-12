using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int score;

    private void Awake()
    {
        score = 0;  
    }

    public int upp() 
    { 
        score ++;
      return  score;
    }

}
