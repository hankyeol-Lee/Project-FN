using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy instance;
    //���ʹ� ���� �Ŵ�����Ʈ

    //��ġ�� ���ʹ� GO, �� ������ �� prefab�����ֵ��� ��������� ��.
    //enemy�� Enemy �±װ� �پ��־�� �ϸ�, �� polygon collider 2d�� �پ��־�� ��.
    //Enemy GameObject�� �̸��� EnemyInstances ��ųʸ��� key�� �Ϻ��ϰ� �����ؾ� ��.
    //�� ���ʹ� GameObject �Ʒ����� prefab EnemyState�� �����Ǿ�����.
    public Tilemap tilemap;
    
    // ���� � ���ʹ̰� �����Ǿ��ִ����� üũ�ϴ� ��ųʸ�
    public Dictionary<string, GameObject> enemyInstances = new Dictionary<string, GameObject>();

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        tilemap = GameManager.Instance.tilemap;
        void SpawnEnemies()
        {
            // ����� ���ʹ� �̸� ����Ʈ
            List<string> enemyNames = new List<string>
        {
            "GiantRat", 
            "WeedSpirit", 
            "Slime", 
            "Goblin", 
        };

            int numberOfEnemies = 4; // ������ ���ʹ� ��
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // ���ʹ� �̸� ���� ����
                string enemyName = enemyNames[Random.Range(0, enemyNames.Count)];

                // Ÿ�ϸʿ��� ���� �� ��ġ ����
                Vector3Int randomCell = GetRandomTilePosition();
                Vector3 spawnPos = tilemap.GetCellCenterWorld(randomCell);

                // ���ʹ� ����
                SpawnEnemyAtCell(enemyName, spawnPos);
            }
        }

        SpawnEnemies();
    }
    private Vector3Int GetRandomTilePosition()
    {
        // Ÿ�ϸ��� ��� (BoundsInt) ��������
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int randomCell;

        do
        {
            // ���� �� ���� ��ǥ ����
            int randomX = Random.Range(bounds.xMin, bounds.xMax);
            int randomY = Random.Range(bounds.yMin, bounds.yMax);
            randomCell = new Vector3Int(randomX, randomY, 0);
        }
        while (!tilemap.HasTile(randomCell)); // Ÿ���� ���� ���� ����
        Debug.Log(randomCell);
        return randomCell;
    }

    public void SpawnEnemyAtCell(string enemyName, Vector3 spawnPos)
    {
        GameObject enemyPrefab = Resources.Load<GameObject>($"Prefab/Enemy/{enemyName}");
        //spawnPos�� �ִ� cell�� ã�Ƽ�, �� cell�� �߾� ��ġ�� �ٽ� ��ȯ.

        Vector3 CellCenterPos(Vector3 worldTransform) // �� ��ǥ�� �ִ� ���� �߾� ��ǥ�� ��ȯ.
        {
            Vector3Int cellPos = GameManager.Instance.PlayerWorldToCell(worldTransform);

            return GameManager.Instance.PlayerCellToWorld(cellPos); 
        }

        spawnPos = CellCenterPos(spawnPos); // ���� �߾���ġ ��ȯ.

        if (enemyPrefab != null )
        {
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            if (!enemyInstances.ContainsKey(enemyName))
            {
                enemyInstances.Add(enemyName, enemyInstance); // ��ųʸ��� �߰�
                
            }
            else
            {
                Debug.LogWarning("�̹� ������");
            }
            //�ڽİ�ü�� EnemyStateInstance ����
            GameObject enemyStatePrefab = Resources.Load<GameObject>($"Prefab/EnemyState");
            GameObject enemyStateInstance = Instantiate(enemyStatePrefab, enemyInstance.transform);
            enemyStateInstance.transform.localPosition = Vector3.zero; // �θ��� �߾ӿ� ��ġ




        }
    }
    public void EnemyEliminate(string enemyName)
    {
        if (enemyInstances.ContainsKey(enemyName))
        {
            // ��ųʸ����� �� GameObject�� ������
            GameObject enemyInstance = enemyInstances[enemyName];

            // ���� ���� ������Ʈ ����
            Destroy(enemyInstance);

            // ��ųʸ����� �ش� �� ����
            enemyInstances.Remove(enemyName);

            Debug.Log($"{enemyName} has been eliminated.");
        }
    }

}
