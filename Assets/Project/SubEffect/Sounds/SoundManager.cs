using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }  //싱글톤


    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    



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

    public void SetBgm(float volume, float pitch = 1f ) // 피치는 배속  
    {
        bgm.volume = volume;    
        bgm.pitch = pitch;  
    }

    public void PlaySfx(AudioClip clip) 
    {
        sfx.PlayOneShot(clip);  // 동시에 플레이 되도록 겹쳐서 재생 

        //sfx.clip = clip;
        //sfx.Play();
    }
    public void setSfx(float volume, float pitch = 1f)
    {
        sfx.volume = volume;
        sfx.pitch = pitch;
    }
}
