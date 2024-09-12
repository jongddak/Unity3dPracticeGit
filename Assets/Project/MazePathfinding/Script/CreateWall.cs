using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    [SerializeField] GameObject wallPrefab;
    private const int WIDTH = 19;  // �̷� �ʺ�
    private const int HEIGHT = 19; // �̷� ����
    private int[,] maze = new int[WIDTH, HEIGHT];
    private System.Random rand = new System.Random();

    // �����¿� �̵��� ���� ���� ����
    private int[] dx = { 0, 1, 0, -1 };
    private int[] dy = { -1, 0, 1, 0 };
    public Vector3 startPosition = new Vector3(-19f, 0f, -19f); // �̷� ���� ��ġ

    private void Start()
    {
        GenerateMaze();
        StartCoroutine(Draw());
    }

    public void GenerateMaze()
    {
        // ó���� ��� ������ ä��
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                maze[x, y] = 1; // 1�� ���� �ǹ�
            }
        }

        // �̷� ���� ���� (������ ����, �׻� Ȧ�� ��ġ���� ����)
        CarvePath(1, 1);
    }

    // �̷��� ���� ����� ��� �Լ�
    private void CarvePath(int x, int y)
    {
        maze[x, y] = 0; // 0�� ���� �ǹ�

        // �����ϰ� 4������ ����
        List<int> directions = new List<int> { 0, 1, 2, 3 };
        Shuffle(directions);

        foreach (int dir in directions)
        {
            int newX = x + dx[dir] * 2;
            int newY = y + dy[dir] * 2;

            // �̷� �ٱ� ��踦 ���� �ʰ� �ϰ�, ���� �湮���� ���� ������ Ȯ��
            if (IsInBounds(newX, newY) && maze[newX, newY] == 1)
            {
                // ���ο� ��� ���� ���� �ν��� ����
                maze[x + dx[dir], y + dy[dir]] = 0;
                CarvePath(newX, newY); // ��������� ��� ���� ����
            }
        }
    }

    // �̷� ��� üũ �Լ�
    private bool IsInBounds(int x, int y)
    {
        return x > 0 && x < WIDTH - 1 && y > 0 && y < HEIGHT - 1;
    }

    // ����Ʈ�� �����ϰ� ���� �Լ�
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

    // �̷θ� �׸��� �Լ�
    IEnumerator Draw()
    {
        // ��� ��ǥ�� üũ�Ͽ� ���� ����
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                // ���� 4x4 ũ��� ���� ���� �ε��� ����
                if (maze[x, y] == 1)
                {
                    // ���� ������ �� ��ġ ����
                    Vector3 position = new Vector3(startPosition.x + x * 2f, 0f, startPosition.z + y * 2f);
                    yield return new WaitForSeconds(0.05f);
                    Instantiate(wallPrefab, position, Quaternion.identity); // �� ������ ����
                }
                // ��(maze[x, y] == 0)�� �ƹ��͵� �������� ����
            }
        }
    }
}