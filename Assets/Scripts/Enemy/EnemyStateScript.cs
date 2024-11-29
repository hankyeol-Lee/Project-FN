using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using Enemyspace;

public class EnemyStateScript : MonoBehaviour
{
    // 상태를 정의하는 enum
    public enum EnemyState { Wait, Move, Attack }
    public EnemyState enemyState = EnemyState.Wait; // 초기 상태는 Wait

    public GameObject enemyobject; // Enemy 객체
    public Transform playertransform;
    public Vector3 nextCellPosition; // 다음 이동할 Cell의 위치
    public Enemy enemy;
    public Tilemap tilemap;
    public ActiveSkill thisSkill;

    private void OnEnable()
    {
        enemyobject = transform.parent.gameObject;
        string cleanedName = enemyobject.name.Replace("(Clone)", "").Trim();
        enemyobject.name = cleanedName;
        playertransform = GameManager.Instance.player.GetComponent<Transform>();
        tilemap = GameManager.Instance.tilemap;

        if (EnemyInstances.enemyDict.TryGetValue(cleanedName, out Enemy enemy))
        {
            this.enemy = enemy;
            thisSkill = enemy.enemySkillList[0];
        }
        else
        {
            Debug.LogWarning($"{enemyobject}제대로 지정 안됐어요.");
        }

        // 상태 관리 코루틴 시작
        StartCoroutine(StateManager());
    }

    // 상태를 관리하는 코루틴
    private IEnumerator StateManager()
    {
        while (true)
        {
            switch (enemyState)
            {
                case EnemyState.Wait:
                    yield return new WaitForSeconds(1f);

                    if (checkDistancetoPlayer()) // 공격 거리 확인
                    {
                        enemyState = EnemyState.Attack;
                    }
                    else
                    {
                        enemyState = EnemyState.Move; // Move 상태로 전환
                    }
                    break;

                case EnemyState.Move:
                    Vector3 startWorldPos = enemyobject.transform.position;
                    Vector3 endWorldPos = nextCellPos();

                    // 이동 코루틴 실행
                    yield return StartCoroutine(MoveCell(enemyobject, startWorldPos, endWorldPos));

                    // 이동 후 다시 Wait 상태로 전환
                    enemyState = EnemyState.Wait;
                    yield return new WaitForSeconds(2f);
                    break;

                case EnemyState.Attack:
                    yield return new WaitForSeconds(0.5f);
                    enemy.Attack(enemyobject);
                    enemyState = EnemyState.Wait;
                    break;
            }
        }
    }

    // 다음 이동할 셀의 월드 좌표 계산
    private Vector3 nextCellPos()
    {
        Vector3Int enemyPos = tilemap.WorldToCell(enemyobject.transform.position);
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);

        // 플레이어 방향으로 타일이 있는 유효한 위치를 계산
        Vector3Int targetPos = GetValidTargetPos(enemyPos, playerPos);

        return tilemap.CellToWorld(targetPos); // 타일맵 좌표를 월드 좌표로 변환
    }

    // 유효한 타일 위치를 반환
    private Vector3Int GetValidTargetPos(Vector3Int enemyPos, Vector3Int playerPos)
    {
        Vector3Int[] possibleMoves = new Vector3Int[]
        {
            new Vector3Int(enemyPos.x + 1, enemyPos.y, 0),
            new Vector3Int(enemyPos.x - 1, enemyPos.y, 0),
            new Vector3Int(enemyPos.x, enemyPos.y + 1, 0),
            new Vector3Int(enemyPos.x, enemyPos.y - 1, 0)
        };

        Vector3Int bestMove = enemyPos;
        float shortestDistance = float.MaxValue;

        foreach (Vector3Int move in possibleMoves)
        {
            if (tilemap.HasTile(move)) // 타일 유효성 확인
            {
                float distance = Vector3Int.Distance(move, playerPos);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestMove = move;
                }
            }
        }

        return bestMove; // 유효한 위치 반환
    }

    // 객체를 이동시키는 MoveCell 코루틴
    private IEnumerator MoveCell(GameObject mover, Vector3 startWorldPos, Vector3 endWorldPos)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            mover.transform.position = Vector3.Lerp(startWorldPos, endWorldPos, t);
            yield return null;
        }

        // 정확히 목표 위치에 설정
        mover.transform.position = endWorldPos;
    }

    // 플레이어와의 거리 확인
    private bool checkDistancetoPlayer()
    {
        int GetHexTileDistance(Vector3 enemyWorldPos, Vector3 playerWorldPos)
        {
            Vector3 enemyCellCenter = CellCenterPos(enemyWorldPos);
            Vector3 playerCellCenter = CellCenterPos(playerWorldPos);

            Vector3Int CubeCoordinates(Vector3Int cellPos)
            {
                int x = cellPos.x;
                int z = cellPos.y - (cellPos.x + (cellPos.x & 1)) / 2; // 큐브 좌표 변환 (Even-r 기준)
                int y = -x - z;
                return new Vector3Int(x, y, z);
            }

            Vector3Int enemyCell = tilemap.WorldToCell(enemyCellCenter);
            Vector3Int playerCell = tilemap.WorldToCell(playerCellCenter);

            Vector3Int enemyCube = CubeCoordinates(enemyCell);
            Vector3Int playerCube = CubeCoordinates(playerCell);

            return Mathf.Max(
                Mathf.Abs(enemyCube.x - playerCube.x),
                Mathf.Abs(enemyCube.y - playerCube.y),
                Mathf.Abs(enemyCube.z - playerCube.z)
            );
        }

        return GetHexTileDistance(enemyobject.transform.position, playertransform.position) <= thisSkill.distance;
    }

    // 월드 좌표의 셀 중심 좌표 반환
    private Vector3 CellCenterPos(Vector3 worldTransform)
    {
        Vector3Int cellPos = tilemap.WorldToCell(worldTransform);
        return tilemap.CellToWorld(cellPos);
    }
}
