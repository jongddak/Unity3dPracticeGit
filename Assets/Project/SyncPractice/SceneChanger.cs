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
        
        // SceneManager.LoadScene(Scene); // ����� �ε� 
        // AsyncOperation oper=  SceneManager.LoadSceneAsync(Scene);  // �񵿱�� �ε� 


        //float pro = oper.progress; // ����� 
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
                // �ε���
                Debug.Log(oper.progress);
                loadingSlide.value = oper.progress;
                
            }
            else
            {
                // �ε��Ϸ� 
                Debug.Log("�ε��Ϸ�");
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
