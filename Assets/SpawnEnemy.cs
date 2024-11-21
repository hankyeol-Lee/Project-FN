using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemy : MonoBehaviour
{
    //���ʹ� ���� �Ŵ�����Ʈ

    //��ġ�� ���ʹ� GO, �� ������ �� prefab�����ֵ��� ��������� ��.
    //enemy�� Enemy �±װ� �پ��־�� �ϸ�, �� polygon collider 2d�� �پ��־�� ��.
    //Enemy GameObject�� �̸��� EnemyInstances ��ųʸ��� key�� �Ϻ��ϰ� �����ؾ� ��.
    //�� ���ʹ� GameObject �Ʒ����� prefab EnemyState�� �����Ǿ�����.

    
    // ���� � ���ʹ̰� �����Ǿ��ִ����� üũ�ϴ� ��ųʸ�
    public Dictionary<string, GameObject> enemyInstances = new Dictionary<string, GameObject>();

    public void Start()
    {
        //         GameManager.Instance.EnemySpawner.GetComponent<SpawnEnemy>().
        SpawnEnemyAtCell("Slime", new Vector3(3.72f, -1.1f, 0));
        SpawnEnemyAtCell("GiantRat",new Vector3(0f,0f,0f));
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

}
