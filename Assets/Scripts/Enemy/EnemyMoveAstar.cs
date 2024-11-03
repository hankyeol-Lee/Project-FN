using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps;

public class EnemyMoveAstar : MonoBehaviour
{
    private bool enemymoving = false;
    public Tilemap tilemap;
    public Transform playertransform;
    public GameObject gamemanager;
    private Vector3Int targetCell;


    

    public void EnemyMovetoPlayer()
    {
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        HashSet<Hex> obstacles = new HashSet<Hex>();

        List<Vector3Int> enemypath = new List<Vector3Int>();

        // 적이 이동 중일 때만 경로를 갱신
        if (!enemymoving)
        {
            enemymoving = true;
            // 새 경로에 따라 이동 코루틴 실행
        }
        else // 움직이고 있을 경우의 새로운 경로 설정.
        {
            //StopAllCoroutines();
            playerPos = tilemap.WorldToCell(playertransform.position);
            thisObjPos = tilemap.WorldToCell(transform.position) ;
        }
        Debug.Log($"현재 위치 : {thisObjPos}");
        Debug.Log($"현재 움직이는 상태 : {enemymoving}");
        enemypath = HexClass.HexPathfinding.FindPath(thisObjPos,  playerPos, obstacles);
        Debug.Log("길 찾았어요");
        StartCoroutine(EnemyMovePath(enemypath));

    }

    IEnumerator EnemyMovePath(List<Vector3Int> path)
    {
        Vector3 startWorldPos;
        Vector3 endWorldPos;

        // 경로를 따라 이동
        foreach (var cell in path)
        {
            startWorldPos = tilemap.CellToWorld(tilemap.WorldToCell(transform.position)); // 현재 위치
            endWorldPos = tilemap.CellToWorld(cell); // 목표 위치

            // 적을 목표 위치로 이동
            yield return StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, startWorldPos, endWorldPos));

            // 한 셀 이동 후 잠시 대기
            yield return new WaitForSeconds(1.0f);
        }

        enemymoving = false;  // 이동 완료 후 이동 가능 상태로 설정
    }
}
