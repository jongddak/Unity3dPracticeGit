using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTester : MonoBehaviour
{
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;

    private void Update()
    {
        SoundManager.Instance.PlayBgm(clip1);
       // SoundManager.Instance.PlayBgm(clip2);

    }
}
