using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform FirePoint;
    [SerializeField] Transform BoomPoint;
    [SerializeField] GameObject flash;

    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip chalkaksound;

    [SerializeField] GameObject Soundplayer;

    [SerializeField] ParticleSystem shootingFire;
    [SerializeField] LineRenderer bulletTrail;

    [SerializeField] GameObject hitEffect1;

    [SerializeField] GameObject BoomPrefab;

    



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


            RaycastHit hit;

            if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit, 100f)) 
            {
                StartCoroutine(DrawLine(hit.point));
                HitEffect(hitEffect1,hit);
            }
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
            // => 결론 총구에서(transform) 레이캐스트해서 힛 한 부분에 데칼 + 라인렌더러 !
        }
    }
    IEnumerator DrawLine(Vector3 hitPoint) 
    {
        bulletTrail.SetPosition(0, FirePoint.transform.position);  // 시작점 
        bulletTrail.SetPosition(1, hitPoint);
        bulletTrail.enabled = true;

        yield return new WaitForSeconds(0.1f);
        bulletTrail.enabled = false;
    }

    private void HitEffect(GameObject effect1,  RaycastHit hit) 
    {
        GameObject eff1 = Instantiate(effect1, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(eff1,2f);
    }

    private void ThrowBoom()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {   

            //붐 포인트에서 Instantiate(); 리지드바디,오디오소스 , 오디오 클립 , 파티클 이펙트 적용된 프리팹 만들어서 던지면 될듯  
            Instantiate(BoomPrefab, BoomPoint.position, BoomPoint.rotation);
           
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
