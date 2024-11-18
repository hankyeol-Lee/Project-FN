using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
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

    private void Start()
    {
        enemyobject = transform.parent.gameObject;
        if(EnemyInstances.enemyDict.TryGetValue(enemyobject.name,out Enemy enemy))
        {
            this.enemy = enemy;
        }
        thisSkill = enemy.enemySkillList[0];
        // 코루틴을 시작해서 2초 후 상태를 Move로 바꿈
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
                    // Wait 상태에서는 2초를 대기
                    yield return new WaitForSeconds(2f);
                    // 만약 플레이어와의 셀 거리가 thisskill.skillcelldist 이하라면 if (thisSkill.skillcelldist)
                    if (checkDistancetoPlayer())
                    {
                        enemyState = EnemyState.Attack;
                        Debug.Log(enemyState);
                    }
                    else
                    {
                        enemyState = EnemyState.Move; // 상태를 Move로 변경
                        Debug.Log(enemyState);
                    }
                    Debug.Log(enemyState);
                    //Debug.Log($"2초 지남. 현재 EnemyState : {enemyState}");
                    //TODO : 여기에서 2초 기다리는 애니메이션 실행해야함 ㅇㅇ
                    break;

                case EnemyState.Move:
                    // 이동 상태로 전환하면 이동 코루틴 실행
                    //Debug.Log($"현재 EnemyState : {enemyState}");
                    //Vector3 startWorldPos = enemy.transform.position;
                    yield return StartCoroutine(MoveCell(enemyobject, CellCenterPos(enemyobject.transform.position), nextCellPos()));

                    // 이동이 끝나면 다시 Wait 상태로 전환하고 2초 대기
                    enemyState = EnemyState.Wait;
                    Debug.Log(enemyState);
                    yield return new WaitForSeconds(2f);
                    break;

                case EnemyState.Attack:
                    yield return new WaitForSeconds(1f);
                    enemy.Attack(enemyobject);
                    enemyState = EnemyState.Wait;
                    // Attack 상태에서의 로직 (추가적인 조건에 따라 구현)
                    break;
            }

            // 무한 루프가 아니라 특정 조건에서 종료하고 싶다면 종료 조건 추가 가능
        }
    }
    
    private Vector3 nextCellPos() // Enemy가 이동할 다음 cell을 정하는 코드.
    {
        void SettargetPos(Vector3Int thisObjPos, Vector3Int playerPos, ref Vector3Int targetPos)
        {
            bool isOddRow = Mathf.Abs(thisObjPos.y % 2) == 1; // 홀수 행인지 확인
            bool isPlayerOnRight = playerPos.y > thisObjPos.y; // 플레이어가 더 오른쪽에 있는지 판단
            if (playerPos.y == thisObjPos.y) // 같은 행에 있는 경우
            {
                targetPos.x += (playerPos.x > thisObjPos.x) ? 1 : -1; // 플레이어가 위쪽이면 +1, 아니면 -1
            }
            else if (isPlayerOnRight) // 플레이어가 오른쪽에 있는 경우
            {
                targetPos.y += 1;
                if (isOddRow)
                {
                    targetPos.x += UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
                else
                {
                    targetPos.x -= UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
            }
            else // 플레이어가 왼쪽에 있는 경우
            {
                targetPos.y -= 1;
                if (isOddRow)
                {
                    targetPos.x += UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;

                }
                else
                {
                    targetPos.x -= UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
            }
        }
        Vector3Int enemyPos = tilemap.WorldToCell(enemyobject.transform.position);
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int targetPos = enemyPos;
        SettargetPos(enemyPos,playerPos,ref targetPos); // targetPos의 위치를 제대로 정함.
        //Debug.Log($"다음에 이동할 곳 : {targetPos}");
        return tilemap.CellToWorld(targetPos); // targetPos를 월드좌표로 변환.
    }
    

    // 객체를 이동시키는 MoveCell 코루틴
    IEnumerator MoveCell(GameObject mover, Vector3 startWorldPos, Vector3 endWorldPos)
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

        // 정확하게 목표 위치로 설정
        mover.transform.position = endWorldPos;
    }

    public Vector3 CellCenterPos(Vector3 worldTransform) // 이 좌표가 있는 셀의 중앙 좌표를 반환.
    {
        Vector3Int cellPos = tilemap.WorldToCell(worldTransform);

        return tilemap.CellToWorld(cellPos); // 월드좌표로 반환.
    }
    
    private bool checkDistancetoPlayer()
    {
        int GetHexTileDistance(Vector3 enemyWorldPos, Vector3 playerWorldPos)
        {
            // 적과 플레이어의 셀 중심 좌표 계산
            Vector3 enemyCellCenter = CellCenterPos(enemyWorldPos);
            Vector3 playerCellCenter = CellCenterPos(playerWorldPos);

            // 셀 좌표를 큐브 좌표로 변환하는 함수
            Vector3Int CubeCoordinates(Vector3Int cellPos)
            {
                int x = cellPos.x;
                int z = cellPos.y - (cellPos.x + (cellPos.x & 1)) / 2; // Even-r 기준
                int y = -x - z;
                return new Vector3Int(x, y, z);
            }

            // 월드 좌표 -> 셀 좌표 변환
            Vector3Int enemyCell = tilemap.WorldToCell(enemyCellCenter);
            Vector3Int playerCell = tilemap.WorldToCell(playerCellCenter);

            // 셀 좌표 -> 큐브 좌표 변환
            Vector3Int enemyCube = CubeCoordinates(enemyCell);
            Vector3Int playerCube = CubeCoordinates(playerCell);

            // 큐브 거리 계산
            int distance = Mathf.Max(
                Mathf.Abs(enemyCube.x - playerCube.x),
                Mathf.Abs(enemyCube.y - playerCube.y),
                Mathf.Abs(enemyCube.z - playerCube.z)
            );

            return distance;
        }
        if (GetHexTileDistance(enemyobject.transform.position,GameManager.Instance.player.transform.position) <= thisSkill.distance)
        {
            return true;
        }
        return false;
    }
}
