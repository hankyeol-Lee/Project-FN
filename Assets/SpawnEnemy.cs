using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy instance;
    //에너미 스폰 매니지먼트

    //위치와 에너미 GO, 그 하위에 들어갈 prefab같은애들을 연결해줘야 함.
    //enemy는 Enemy 태그가 붙어있어야 하며, 또 polygon collider 2d가 붙어있어야 함.
    //Enemy GameObject의 이름은 EnemyInstances 딕셔너리의 key와 완벽하게 동일해야 함.
    //각 에너미 GameObject 아래에는 prefab EnemyState가 지정되어있음.

    public Tilemap tilemap;
    // 현재 어떤 에너미가 생성되어있는지를 체크하는 딕셔너리
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
            Vector3 center = Vector3.zero; // 중심점
            float minDistance = 3.0f; // 중심에서 최소 거리

            // 타일맵의 크기 가져오기
            BoundsInt bounds = tilemap.cellBounds;

            while (spawnedCount < selectedEnemies.Count)
            {
                // 랜덤 위치 생성
                int randomX = UnityEngine.Random.Range(bounds.xMin, bounds.xMax);
                int randomY = UnityEngine.Random.Range(bounds.yMin, bounds.yMax);
                Vector3Int randomCell = new Vector3Int(randomX, randomY, 0);

                // 위치 조건 확인
                if (tilemap.HasTile(randomCell)) // 타일이 있는 위치인지 확인
                {
                    float distance = Vector3.Distance(center, randomCell);
                    if (distance >= minDistance) // 중심에서 최소 거리 조건 확인
                    {
                        // 에너미 소환
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
    public void EnemyEliminate(string enemyName)
    {
        if (enemyInstances.ContainsKey(enemyName))
        {
            // 딕셔너리에서 적 GameObject를 가져옴
            GameObject enemyInstance = enemyInstances[enemyName];

            // 적의 게임 오브젝트 삭제
            Destroy(enemyInstance);

            // 딕셔너리에서 해당 적 제거
            enemyInstances.Remove(enemyName);

            Debug.Log($"{enemyName} has been eliminated.");
        }
    }

}
