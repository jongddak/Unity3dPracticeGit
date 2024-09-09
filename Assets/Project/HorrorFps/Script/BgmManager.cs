using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{

    public static BgmManager Instance { get; private set; }  //싱글톤


    [SerializeField] AudioSource bgm;
  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환에도 끊기지 않음 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBgm(AudioClip clip)
    {
        bgm.clip = clip;

        bgm.Play(); // 재생 
    }

    public void StopBgm()
    {
        if (bgm.isPlaying == false)
        {
            return;
        }
        bgm.Stop();
    }
    public void PauseBgm()
    {
        if (bgm.isPlaying == false)
        {
            return;
        }
        bgm.Pause();
    }

    public void SetBgm(float volume, float pitch = 1f) // 피치는 배속  
    {
        bgm.volume = volume;
        bgm.pitch = pitch;
    }

}
