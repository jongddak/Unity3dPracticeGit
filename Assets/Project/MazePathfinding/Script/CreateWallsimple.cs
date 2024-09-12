using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;




public class CreateWallsimple : MonoBehaviour
{
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] Transform StartPoint;


    public string[,] mazeDatas;


    // 0 = ��
    // 1 = ��
    // 2 = �÷��̾�
    // 3 = �� // ������ �ӵ��� �������� ! 
    // 4 = ���� 
    //private int[,] maze = new int[,] { 
    //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1 },
    //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1 },
    //    { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
    //    { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
    //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    //};
    private void Awake()
    {
        mazeParser();

    }
    private void Start()
    {

        StartCoroutine(Draw());
    }
    private void mazeParser()
    {
        string path = Application.dataPath + "/Project/MazePathfinding/Script";

        string file = File.ReadAllText(path + "/Maze.csv");
        //Debug.Log(file);

       
        string[] lines = file.Split('\n');

        // ù ��° ���� �������� �ʱ� �� �� ���
        mazeDatas = new string[lines.Length, lines[0].Split(',').Length];

        for (int x = 0; x < lines.Length; x++)
        {
            // ��ǥ���� �������� ���� �и�
            string[] values = lines[x].Split(',');

            // ������ ���� �� ���� �� ���ɼ��� �����ϱ� ���� Trim() ���
            for (int y = 0; y < values.Length; y++)
            {
                values[y] = values[y].Trim();  // ���� ����
               // Debug.Log(values[y]);
                mazeDatas[x, y] = values[y];
            }
        }
    }
    IEnumerator Draw()  // ũ�⸦ �������� �ް� ���� , ��ŸƮ ������ ����  
    {
        WaitForSeconds time = new WaitForSeconds(0.02f);

        for (int x = 0; x < mazeDatas.GetLength(0); x++)
        {
            for (int y = 0; y < mazeDatas.GetLength(1); y++)
            {

                if (mazeDatas[x, y] == "Wall")
                {
                    // ���� ������ �� ��ġ ����
                    Vector3 position = new Vector3(StartPoint.position.x + x * 2f, 0f, StartPoint.position.z + y * 2f);
                    yield return time;
                    Instantiate(wallPrefab, position, Quaternion.identity);

                }
                else if (mazeDatas[x, y] == "Player")
                {
                    Vector3 position = new Vector3(StartPoint.position.x + x * 2f, 1.8f, StartPoint.position.z + y * 2f);
                    yield return time;
                    Instantiate(playerPrefab, position, Quaternion.identity);
                }
                else if (mazeDatas[x, y] == "Water")
                {
                    Vector3 position = new Vector3(StartPoint.position.x + x * 2f, 1.05f, StartPoint.position.z + y * 2f);
                    yield return time;
                    Instantiate(waterPrefab, position, Quaternion.identity);
                }
                else if (mazeDatas[x, y] == "Coin")
                {
                    Vector3 position = new Vector3(StartPoint.position.x + x * 2f, 2f, StartPoint.position.z + y * 2f);
                    yield return time;
                    Instantiate(CoinPrefab, position, Quaternion.identity);
                    
                }
                else if (mazeDatas[x, y] == "Road")
                {
                    yield return time;
                    // �� 
                }

            }
        }
    }

}