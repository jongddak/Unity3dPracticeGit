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
    [SerializeField] TrailRenderer bulletTrail;



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

            // 예광탄 효과를 만들려면 트레일 렌더러 (진짜 총알을 보내서 이동시켜야함 )
            // 라인렌더러를 쓰면 힛 한 부분까지 라인렌더링 가능 
            // 레이캐스트 hit 하면 그 부분에 
            //void SpawnImpactEffect(RaycastHit hit)
            //{
            //    // 1.데칼을 맞은 위치에 생성
            //    GameObject decal = Instantiate(bulletHoleDecal, hit.point, Quaternion.LookRotation(hit.normal));
            //    Destroy(decal, 5f); // 5초 후 데칼 제거
            //}
            // 2.진짜 총알을 보내서 충돌기준으로(각각의 마테리얼마다 다르게 만들기 가능 )
            // => 결론 총구에서 레이캐스트해서 힛 한 부분에 데칼 + 라인렌더러 !
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
