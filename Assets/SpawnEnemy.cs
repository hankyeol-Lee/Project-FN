using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemy : MonoBehaviour
{
    //에너미 스폰 매니지먼트

    //위치와 에너미 GO, 그 하위에 들어갈 prefab같은애들을 연결해줘야 함.
    //enemy는 Enemy 태그가 붙어있어야 하며, 또 polygon collider 2d가 붙어있어야 함.
    //Enemy GameObject의 이름은 EnemyInstances 딕셔너리의 key와 완벽하게 동일해야 함.
    //각 에너미 GameObject 아래에는 prefab EnemyState가 지정되어있음.

    
    // 현재 어떤 에너미가 생성되어있는지를 체크하는 딕셔너리
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
        //spawnPos에 있는 cell을 찾아서, 그 cell의 중앙 위치를 다시 반환.

        Vector3 CellCenterPos(Vector3 worldTransform) // 이 좌표가 있는 셀의 중앙 좌표를 반환.
        {
            Vector3Int cellPos = GameManager.Instance.PlayerWorldToCell(worldTransform);

            return GameManager.Instance.PlayerCellToWorld(cellPos); 
        }

        spawnPos = CellCenterPos(spawnPos); // 셀의 중앙위치 반환.

        if (enemyPrefab != null )
        {
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            if (!enemyInstances.ContainsKey(enemyName))
            {
                enemyInstances.Add(enemyName, enemyInstance); // 딕셔너리에 추가
                
            }
            else
            {
                Debug.LogWarning("이미 스폰됨");
            }
            //자식객체로 EnemyStateInstance 생성
            GameObject enemyStatePrefab = Resources.Load<GameObject>($"Prefab/EnemyState");
            GameObject enemyStateInstance = Instantiate(enemyStatePrefab, enemyInstance.transform);
            enemyStateInstance.transform.localPosition = Vector3.zero; // 부모의 중앙에 위치




        }
    }

}
