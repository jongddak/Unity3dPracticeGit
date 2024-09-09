using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }  //�̱���


    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ���� ������ ���� 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBgm(AudioClip clip)
    {
        bgm.clip = clip;

        bgm.Play(); // ��� 
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

    public void SetBgm(float volume, float pitch = 1f ) // ��ġ�� ���  
    {
        bgm.volume = volume;    
        bgm.pitch = pitch;  
    }

    public void PlaySfx(AudioClip clip) 
    {
        sfx.PlayOneShot(clip);  // ���ÿ� �÷��� �ǵ��� ���ļ� ��� 

        //sfx.clip = clip;
        //sfx.Play();
    }
    public void setSfx(float volume, float pitch = 1f)
    {
        sfx.volume = volume;
        sfx.pitch = pitch;
    }
}
