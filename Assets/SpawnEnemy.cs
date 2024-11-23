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
        void SpawnEnemies()
        {
            SpawnEnemyAtCell("Slime", GameManager.Instance.PlayerCellToWorld(new Vector3Int(3, 8, 0)));
            SpawnEnemyAtCell("GiantRat", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-6, 14, 0)));
            SpawnEnemyAtCell("WeedSpirit", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-4, 20, 0)));
            SpawnEnemyAtCell("Goblin", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-11, 17, 0)));
            SpawnEnemyAtCell("Slime", GameManager.Instance.PlayerCellToWorld(new Vector3Int(1, 25, 0)));
            SpawnEnemyAtCell("GiantRat", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-3, 32, 0)));
            SpawnEnemyAtCell("WeedSpirit", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-8, 45, 0)));
            SpawnEnemyAtCell("Goblin", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-19, 32, 0)));
            SpawnEnemyAtCell("Slime", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-22, 44, 0)));
            SpawnEnemyAtCell("GiantRat", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-27, 47, 0)));
            SpawnEnemyAtCell("WeedSpirit", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-25, 38, 0)));
            SpawnEnemyAtCell("Goblin", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-12, 27, 0)));
            SpawnEnemyAtCell("Slime", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-5, 8, 0)));
            SpawnEnemyAtCell("GiantRat", GameManager.Instance.PlayerCellToWorld(new Vector3Int(0, 20, 0)));
            SpawnEnemyAtCell("WeedSpirit", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-7, 53, 0)));
            SpawnEnemyAtCell("Goblin", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-17, 43, 0)));
            SpawnEnemyAtCell("Slime", GameManager.Instance.PlayerCellToWorld(new Vector3Int(-24, 39, 0)));
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
