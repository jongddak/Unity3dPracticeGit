using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]  // ����ü ó�� Ŭ������ ����ȭ�� ���� 
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
        //  string json = JsonUtility.ToJson(gameData); ����ȭ 
        //string json = "{\"Name\":\"dd\",\"level\":123,\"rate\":3.0}";

       // gameData = JsonUtility.FromJson<GameData>(json); // �� ����ȭ  

       // Debug.Log(json);    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Save();
        }
    }

    [ContextMenu("Save")] // �׽�Ʈ�� ���ؽ�Ʈ �޴��� ������ �ۺ��̿��� �� 
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
            Debug.Log("���̺� ���� �ε� ����");
            return;
        }
        string json = File.ReadAllText(path);
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
