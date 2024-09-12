using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]  // 구조체 처럼 클래스도 직렬화가 가능 
public class GameData 
{
    public string Name;
    public int level;
    public float rate;
}

public class JsonTester : MonoBehaviour
{
    [SerializeField] GameData gameData;


    private void Start()
    {
        //  string json = JsonUtility.ToJson(gameData); 직렬화 
        //string json = "{\"Name\":\"dd\",\"level\":123,\"rate\":3.0}";

       // gameData = JsonUtility.FromJson<GameData>(json); // 역 직렬화  

       // Debug.Log(json);    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Save();
        }
    }

    [ContextMenu("Save")] // 테스트용 컨텍스트 메뉴를 쓸때는 퍼블릭이여야 함 
    public void Save()
    {
        string path = $"{Application.dataPath}/Project/DataPractice/";
        
        if (Directory.Exists(path) == false) 
        {
            Directory.CreateDirectory(path);    
        }
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText($"{path}/save.txt", json);
        
    }

    [ContextMenu("Load")]
    public void Load() 
    {
        string path = $"{Application.dataPath}/Project/DataPractice/save.txt";

        if (File.Exists(path) == false) 
        {
            Debug.Log("세이브 파일 로드 실패");
            return;
        }
        string json = File.ReadAllText(path);
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
