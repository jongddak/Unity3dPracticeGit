using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{

    public static BgmManager Instance { get; private set; }  //�̱���


    [SerializeField] AudioSource bgm;
  
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

    public void SetBgm(float volume, float pitch = 1f) // ��ġ�� ���  
    {
        bgm.volume = volume;
        bgm.pitch = pitch;
    }

}
