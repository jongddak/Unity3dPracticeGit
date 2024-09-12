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


    // 0 = 길
    // 1 = 벽
    // 2 = 플레이어
    // 3 = 물 // 물에선 속도가 느려지게 ! 
    // 4 = 코인 
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

        // 첫 번째 줄을 기준으로 초기 열 수 계산
        mazeDatas = new string[lines.Length, lines[0].Split(',').Length];

        for (int x = 0; x < lines.Length; x++)
        {
            // 쉼표만을 기준으로 열을 분리
            string[] values = lines[x].Split(',');

            // 마지막 열에 빈 값이 들어갈 가능성을 제거하기 위해 Trim() 사용
            for (int y = 0; y < values.Length; y++)
            {
                values[y] = values[y].Trim();  // 공백 제거
               // Debug.Log(values[y]);
                mazeDatas[x, y] = values[y];
            }
        }
    }
    IEnumerator Draw()  // 크기를 동적으로 받게 변경 , 스타트 지점은 고정  
    {
        WaitForSeconds time = new WaitForSeconds(0.02f);

        for (int x = 0; x < mazeDatas.GetLength(0); x++)
        {
            for (int y = 0; y < mazeDatas.GetLength(1); y++)
            {

                if (mazeDatas[x, y] == "Wall")
                {
                    // 벽을 생성할 때 위치 조정
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
                    // 길 
                }

            }
        }
    }

}