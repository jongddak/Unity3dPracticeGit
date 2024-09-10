using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SyncTest : MonoBehaviour
{
    public string testname;
    private IEnumerator routine;

    private void Start()
    {
      //  routine = Routine();
      //  StartCoroutine(routine);
       // Task.Run(ThreadFunc);
    }

    private void Update()
    {
       // Debug.Log(testname);
    }

    IEnumerator Routine() 
    {
        while (true) 
        {

            yield return null;

            Debug.Log($"{testname} 코루틴");

        }
    }

    private void ThreadFunc()   
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log($"{i} 쓰레드");
        }
        
    }
}
