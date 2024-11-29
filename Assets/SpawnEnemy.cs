using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            List<string> allEnemies = new List<string>()
            {
                "GiantRat", "GiantRat1", "GiantRat2", "GiantRat3",
                "Slime", "Slime1", "Slime2", "Slime3",
                "WeedSpirit", "WeedSpirit1", "WeedSpirit2", "WeedSpirit3",
                "Goblin", "Goblin1", "Goblin2", "Goblin3"
            };
            List<string> selectedEnemies = allEnemies.OrderBy(x => UnityEngine.Random.value).Take(5).ToList();

            int spawnedCount = 0;
            Vector3 center = Vector3.zero; // �߽���
            float minDistance = 3.0f; // �߽ɿ��� �ּ� �Ÿ�

            // Ÿ�ϸ��� ũ�� ��������
            BoundsInt bounds = tilemap.cellBounds;

            while (spawnedCount < selectedEnemies.Count)
            {
                // ���� ��ġ ����
                int randomX = UnityEngine.Random.Range(bounds.xMin, bounds.xMax);
                int randomY = UnityEngine.Random.Range(bounds.yMin, bounds.yMax);
                Vector3Int randomCell = new Vector3Int(randomX, randomY, 0);

                // ��ġ ���� Ȯ��
                if (tilemap.HasTile(randomCell)) // Ÿ���� �ִ� ��ġ���� Ȯ��
                {
                    float distance = Vector3.Distance(center, randomCell);
                    if (distance >= minDistance) // �߽ɿ��� �ּ� �Ÿ� ���� Ȯ��
                    {
                        // ���ʹ� ��ȯ
                        string enemyName = selectedEnemies[spawnedCount];
                        SpawnEnemyAtCell(enemyName, GameManager.Instance.PlayerCellToWorld(randomCell));
                        spawnedCount++;
                    }
                }
            }
        }
        SpawnEnemies();
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
