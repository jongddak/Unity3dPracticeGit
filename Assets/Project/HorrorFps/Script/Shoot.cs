using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform FirePoint;
    [SerializeField] Transform BoomPoint;
    [SerializeField] GameObject flash;

    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip boom;
    [SerializeField] AudioClip chalkaksound;

    [SerializeField] GameObject Soundplayer;

    [SerializeField] ParticleSystem shootingFire;



    private void Start()
    {
        //flashSound.clip = chalkaksound;
    }

    private void Update()
    {
        Shooting();
        ThrowBoom();
        flashlight();
    }

    private void Shooting()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource audio = Soundplayer.GetComponent<AudioSource>();
            audio.PlayOneShot(shoot);
            shootingFire.Play();
        }
    }

    private void ThrowBoom()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

        }
    }

    private void flashlight()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioSource audio = Soundplayer.GetComponent<AudioSource>();
            audio.clip = chalkaksound;
            audio.Play();
            if (flash.activeSelf == false)
            {

                flash.SetActive(true);
            }
            else if (flash.activeSelf == true)
            {
                flash.SetActive(false);

            }
        }
    }
}
