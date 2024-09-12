using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]   // ����ü�� �̰� ������ �ν�����â���� ������ �νĵ� �ȵ� 
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
    [SerializeField] List<WeaponData> weapons;  // ���Ƿ� ����Ʈ�� �޾����� �������� id�� ���� �ֱ⶧���� ��ųʸ��� �޴°� ���� 
    [SerializeField] Dictionary<int, WeaponData>  weaponsDic = new Dictionary<int,WeaponData>(); // �̱������� �����͸� �����ϴ� ������ �Ŵ����� ����� �� ���� 

    private void Awake()
    {
        //string path = "C:\\UnityProject\\Unity3dPracticeGit\\Assets\\Project\\DataPractice";
        
        string path = Application.dataPath+"/Project/DataPractice"; // ������Ʈ ���  => ���� �����߿� ��� 
       // string perpath = Application.persistentDataPath;  // ���� ���� ����� => ���� ���� �Ϸᶧ ���   
       // Debug.Log(perpath);
        Debug.Log(path);
       
        bool exist = Directory.Exists(path); // File.Exists(path); ���ϵ� ���� 


        Debug.Log(exist);

        string[] files = Directory.GetFiles(path); //.GetFiles(path,"*.csv") ó�� ������ �� �� ����  
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
