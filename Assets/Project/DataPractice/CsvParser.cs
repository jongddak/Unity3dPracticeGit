using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]   // 구조체는 이게 없으면 인스펙터창에서 못보고 인식도 안됨 
public struct WeaponData 
    {
        public int index;
        public string name;
        public int attack;
        public int defense;
        public string desc;
    }
public class CsvParser : MonoBehaviour
{   
    [SerializeField] List<WeaponData> weapons;  // 임의로 리스트로 받았지만 현업에선 id를 같이 주기때문에 딕셔너리로 받는게 나음 
    [SerializeField] Dictionary<int, WeaponData>  weaponsDic = new Dictionary<int,WeaponData>(); // 싱글톤으로 데이터를 관리하는 데이터 매니저를 만들면 더 좋음 

    private void Awake()
    {
        //string path = "C:\\UnityProject\\Unity3dPracticeGit\\Assets\\Project\\DataPractice";
        
        string path = Application.dataPath+"/Project/DataPractice"; // 프로젝트 경로  => 게임 제작중에 사용 
       // string perpath = Application.persistentDataPath;  // 개인 로컬 저장소 => 게임 제작 완료때 사용   
       // Debug.Log(perpath);
        Debug.Log(path);
       
        bool exist = Directory.Exists(path); // File.Exists(path); 파일도 가능 


        Debug.Log(exist);

        string[] files = Directory.GetFiles(path); //.GetFiles(path,"*.csv") 처럼 제한을 줄 수 있음  
        //foreach (string file in files)
        //{
        //    Debug.Log(file);
        //} 

        string file = File.ReadAllText(path+"/Data.csv");
        Debug.Log(file);

        string[] lines = file.Split('\n');
        for (int y=1; y <lines.Length; y++) 
        {   
            WeaponData weaponData = new WeaponData();   
            string[] values  = lines[y].Split(',','\t');
            weaponData.index = int.Parse(values[0]);
            weaponData.name = values[1];
            weaponData.attack = int.Parse(values[2]);
            weaponData.defense = int.Parse(values [3]);
            weaponData.desc = values[4];
            
            weapons.Add(weaponData); 
        }
        
    }
}
