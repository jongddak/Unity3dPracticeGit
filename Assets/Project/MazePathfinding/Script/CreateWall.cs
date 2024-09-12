using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    [SerializeField] GameObject wallPrefab;
    private const int WIDTH = 19;  // 미로 너비
    private const int HEIGHT = 19; // 미로 높이
    private int[,] maze = new int[WIDTH, HEIGHT];
    private System.Random rand = new System.Random();

    // 상하좌우 이동을 위한 방향 설정
    private int[] dx = { 0, 1, 0, -1 };
    private int[] dy = { -1, 0, 1, 0 };
    public Vector3 startPosition = new Vector3(-19f, 0f, -19f); // 미로 시작 위치

    private void Start()
    {
        GenerateMaze();
        StartCoroutine(Draw());
    }

    public void GenerateMaze()
    {
        // 처음엔 모두 벽으로 채움
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                maze[x, y] = 1; // 1은 벽을 의미
            }
        }

        // 미로 생성 시작 (시작점 설정, 항상 홀수 위치에서 시작)
        CarvePath(1, 1);
    }

    // 미로의 길을 만드는 재귀 함수
    private void CarvePath(int x, int y)
    {
        maze[x, y] = 0; // 0은 길을 의미

        // 랜덤하게 4방향을 섞음
        List<int> directions = new List<int> { 0, 1, 2, 3 };
        Shuffle(directions);

        foreach (int dir in directions)
        {
            int newX = x + dx[dir] * 2;
            int newY = y + dy[dir] * 2;

            // 미로 바깥 경계를 넘지 않게 하고, 아직 방문하지 않은 셀인지 확인
            if (IsInBounds(newX, newY) && maze[newX, newY] == 1)
            {
                // 새로운 길로 가는 벽을 부숴서 연결
                maze[x + dx[dir], y + dy[dir]] = 0;
                CarvePath(newX, newY); // 재귀적으로 계속 길을 만듦
            }
        }
    }

    // 미로 경계 체크 함수
    private bool IsInBounds(int x, int y)
    {
        return x > 0 && x < WIDTH - 1 && y > 0 && y < HEIGHT - 1;
    }

    // 리스트를 랜덤하게 섞는 함수
    private void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int swapIndex = rand.Next(i + 1);
            int temp = list[i];
            list[i] = list[swapIndex];
            list[swapIndex] = temp;
        }
    }

    // 미로를 그리는 함수
    IEnumerator Draw()
    {
        // 모든 좌표를 체크하여 벽을 생성
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                // 길을 4x4 크기로 비우기 위해 인덱스 조정
                if (maze[x, y] == 1)
                {
                    // 벽을 생성할 때 위치 조정
                    Vector3 position = new Vector3(startPosition.x + x * 2f, 0f, startPosition.z + y * 2f);
                    yield return new WaitForSeconds(0.05f);
                    Instantiate(wallPrefab, position, Quaternion.identity); // 벽 프리팹 생성
                }
                // 길(maze[x, y] == 0)은 아무것도 생성하지 않음
            }
        }
    }
}