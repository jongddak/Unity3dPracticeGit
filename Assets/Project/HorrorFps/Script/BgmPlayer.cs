using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlayer : MonoBehaviour
{
    [SerializeField] AudioClip Bgm;


    private void Update()
    {
        BgmManager.Instance.PlayBgm(Bgm);
    }
}
