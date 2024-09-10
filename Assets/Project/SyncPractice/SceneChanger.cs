using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Image loadingImage;
    [SerializeField] Slider loadingSlide;
        
    Coroutine loadingRoutine;
    public void ChangeScene(string Scene)
    {
        
        // SceneManager.LoadScene(Scene); // 동기식 로딩 
        // AsyncOperation oper=  SceneManager.LoadSceneAsync(Scene);  // 비동기식 로딩 


        //float pro = oper.progress; // 진행률 
        if (loadingRoutine != null)
            return;

        loadingRoutine = StartCoroutine(LoadingRoutine(Scene));
    }

    IEnumerator LoadingRoutine(string name)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(name);

        oper.allowSceneActivation = false;
        loadingImage.gameObject.SetActive(true);

        while (oper.isDone == false)
        {
            if (oper.progress < 0.9)
            {
                // 로딩중
                Debug.Log(oper.progress);
                loadingSlide.value = oper.progress;
                
            }
            else
            {
                // 로딩완료 
                Debug.Log("로딩완료");
                if (Input.anyKeyDown) 
                {
                    oper.allowSceneActivation = true;
                    loadingImage.gameObject.SetActive(false);
                }
            }
           
            yield return null;
        }
    }
}
