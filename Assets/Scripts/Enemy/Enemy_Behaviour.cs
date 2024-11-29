using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps;
using System;
using static Enemy_Behaviour;

public delegate IEnumerator CoroutineDelegate(EnemyState state);

public class Enemy_Behaviour : MonoBehaviour
{
    public Transform playertransform; // 플레이어의 위치를 참조
    public Tilemap tilemap;
    public GameObject gamemanager;

    // EnemyState 열거형 정의
    public enum EnemyState
    {
        Wait,
        Move,
        Attack
    };

    // 상태 변수와 변경 이벤트
    private EnemyState _enemystate; // 내부 상태 변수
    public CoroutineDelegate OnStateChanged;

    private EnemyState enemystate
    {
        get { return _enemystate; }
        set
        {
            if (_enemystate != value)
            {
                if (OnStateChanged != null)
                {
                    StartCoroutine(OnStateChanged(value));  // null 체크 추가
                }
                else
                {
                    Debug.LogWarning("OnStateChanged가 null입니다.");
                }

                _enemystate = value;
                Debug.Log($"10. 내부변수 : {_enemystate}");
            }
        }
    }



    private void Awake()
    {
        // 상태 변경 이벤트 핸들러 등록
        OnStateChanged = HandleStateChanged;
        Debug.Log("1. 핸들러 함수 등록");

    }

    private IEnumerator Start()
    {
        // 상태를 Wait로 설정하고 잠시 대기
        enemystate = EnemyState.Wait;
        Debug.Log($"3. enemySTATE를 wait으로 변경 끝. {enemystate}");

        // Wait 상태에서 약간의 대기
        yield return new WaitForSeconds(1f);

        // 상태를 Move로 변경하여 이벤트 트리거
        enemystate = EnemyState.Move;
        Debug.Log($"11. enemySTATE를 Move으로 변경 끝. {enemystate}");
    }


    // 상태가 변경되었을 때 호출되는 함수
    private IEnumerator HandleStateChanged(EnemyState newState)
    {
        if (newState == EnemyState.Move)
        {
            Debug.Log($"4 이벤트핸들러의 newstate : {newState}");

            Debug.Log("5. move로 전환됨. 코루틴시작!");
            MoveToPlayerCell();
            // 여기에 이제 전역 변수 state를 wait으로 바꾸도록.
            Debug.Log("9. 나 움직였음");
            yield return null;
            //MoveToPlayerCellCoroutine(); // 상태가 Move로 변경되면 이동 코루틴 시작
        }
        if (newState == EnemyState.Wait)
        {
            Debug.Log($"2. 이벤트 핸들러의 newState : {newState}");
            yield return null;
        }
    }

    // 플레이어 위치로 이동하는 코루틴
    public void MoveToPlayerCell()
    {
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position); // 플레이어의 타일맵 좌표
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position); // 적의 현재 타일맵 좌표
        Vector3Int targetPos = thisObjPos; // 이동 목표 타일맵 좌표 초기화

        Debug.Log($"6. 플레이어 위치: {playerPos}, 적의 현재 위치: {thisObjPos}");

        // 플레이어 방향으로 이동 좌표를 설정하고 타일 유효성을 보장
        Vector3Int GetValidTargetPos(Vector3Int currentPos, Vector3Int targetPos)
        {
            // 플레이어 방향으로 이동 후보 생성
            List<Vector3Int> possibleMoves = new List<Vector3Int>
        {
            new Vector3Int(currentPos.x + 1, currentPos.y, 0),   // 오른쪽
            new Vector3Int(currentPos.x - 1, currentPos.y, 0),   // 왼쪽
            new Vector3Int(currentPos.x, currentPos.y + 1, 0),   // 위쪽
            new Vector3Int(currentPos.x, currentPos.y - 1, 0),   // 아래쪽
        };

            // 후보 위치를 거리 기준으로 정렬
            possibleMoves.Sort((a, b) =>
                Vector3Int.Distance(a, targetPos).CompareTo(Vector3Int.Distance(b, targetPos)));

            // 타일맵 상에서 유효한 위치 반환
            foreach (var move in possibleMoves)
            {
                if (tilemap.HasTile(move)) // 타일맵에 타일이 있는지 확인
                {
                    return move;
                }
            }

            // 유효한 위치가 없으면 현재 위치 반환
            return currentPos;
        }

        // 목표 위치 계산
        targetPos = GetValidTargetPos(thisObjPos, playerPos);
        Debug.Log($"7. 이동할 위치: {targetPos}");

        // 타일맵 좌표를 월드 좌표로 변환
        Vector3 targetWorldPos = tilemap.CellToWorld(targetPos);

        // 이동 코루틴 호출
        StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, transform.position, targetWorldPos));
    }
}

