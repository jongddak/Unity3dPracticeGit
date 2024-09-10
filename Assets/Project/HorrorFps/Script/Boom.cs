using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] AudioSource Audio;
    
    [SerializeField] AudioClip boom;
    [SerializeField] ParticleSystem ExplosioveParticle;
    [SerializeField] Rigidbody rb;


   
    private void Start()
    {

        GameObject form =  GameObject.FindGameObjectWithTag("Player");
        rb.AddForce(form.transform.forward * 10f,ForceMode.Impulse);
        StartCoroutine(Explosive());
    }

    
    IEnumerator Explosive() 
    {
        yield return new WaitForSeconds(3f);
        Audio.clip = boom;
        Audio.Play();
        ExplosioveParticle.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
