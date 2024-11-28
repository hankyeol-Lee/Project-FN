using System.Collections;
using System.Collections.Generic;
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
            // 사용할 에너미 이름 리스트
            List<string> enemyNames = new List<string>
        {
            "GiantRat", 
            "WeedSpirit", 
            "Slime", 
            "Goblin", 
        };

            int numberOfEnemies = 4; // 생성할 에너미 수
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // 에너미 이름 랜덤 선택
                string enemyName = enemyNames[Random.Range(0, enemyNames.Count)];

                // 타일맵에서 랜덤 셀 위치 선택
                Vector3Int randomCell = GetRandomTilePosition();
                Vector3 spawnPos = tilemap.GetCellCenterWorld(randomCell);

                // 에너미 스폰
                SpawnEnemyAtCell(enemyName, spawnPos);
            }
        }

        SpawnEnemies();
    }
    private Vector3Int GetRandomTilePosition()
    {
        // 타일맵의 경계 (BoundsInt) 가져오기
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int randomCell;

        do
        {
            // 범위 내 랜덤 좌표 생성
            int randomX = Random.Range(bounds.xMin, bounds.xMax);
            int randomY = Random.Range(bounds.yMin, bounds.yMax);
            randomCell = new Vector3Int(randomX, randomY, 0);
        }
        while (!tilemap.HasTile(randomCell)); // 타일이 없는 셀은 제외
        Debug.Log(randomCell);
        return randomCell;
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
