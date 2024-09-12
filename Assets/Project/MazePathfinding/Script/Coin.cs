using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{   
    [SerializeField] AudioClip clip;
    

    private void OnCollisionEnter(Collision collision)
    {
        
        StartCoroutine(sound());
        Destroy(gameObject,0.05f);
    }

    IEnumerator sound() 
    {
        yield return null;
        
        GameObject saudio = GameObject.FindGameObjectWithTag("Manager");
        GameObject sui = GameObject.FindGameObjectWithTag("Ui");
        TextMeshProUGUI text = sui.GetComponent<TextMeshProUGUI>();
        int up = saudio.GetComponent<Score>().upp();
        text.text =  up.ToString(); 
        AudioSource ssa = saudio.GetComponent<AudioSource>();
        ssa.clip = clip;
        ssa.Play();
        
        
    }


}

