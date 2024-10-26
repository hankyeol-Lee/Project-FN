using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps;
using JetBrains.Annotations;
using System.Runtime.CompilerServices; // 타일맵 이동을 위한 hexclass 네임스페이스 사용
public class Enemy_Behaviour : MonoBehaviour
{
    public Transform playertransform; // 플레이어의 위치를 참조할 수 있게, 전역변수 선언.
    public Tilemap tilemap;
    public GameObject gamemanager; // gamemanager여도 일단은 empty go로 생성했음.

    private void Start()
    {
        InvokeRepeating("MoveToPlayerCellCoroutine", 0f, 2.0f); // InvokeRepeat을 이용해서 코루틴의 반복 실행(하지만 string이라 위험함.)
    }

    public void MoveToPlayerCellCoroutine()
    {
        StartCoroutine(MoveToPlayerCell());
    }
    public IEnumerator MoveToPlayerCell() //
    {
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        Vector3Int targetPos = thisObjPos; // 타겟 포지션 변수

        Debug.Log($"플레이어위치 : {playerPos}, 내 위치 : {thisObjPos}");

        // 이동 조건을 세팅해야함.


        void SettargetPos(Vector3Int thisObjPos, Vector3Int playerPos, ref Vector3Int targetPos)
        {
            // 1. 현재 행이 홀수인지 짝수인지 체크
            bool isOddRow = Mathf.Abs(thisObjPos.y % 2) == 1; // true이면 홀수 행, false이면 짝수 행
           

            // 2. 플레이어가 더 오른쪽에 있는지, 더 왼쪽에 있는지 판단
            bool isPlayerOnRight = playerPos.y > thisObjPos.y;

            // 3. y 좌표가 동일한 경우 x 좌표 비교로 이동 (세로로만 움직이는 경우)
            if (playerPos.y == thisObjPos.y)
            {
                // x 좌표 비교
                if (playerPos.x > thisObjPos.x) // 플레이어가 더 위에 있으면
                {
                    targetPos.x += 1; // 올라오기
                }
                else
                {
                    targetPos.x -= 1; // 아니면 내려가기.
                }
            }
            else if (isPlayerOnRight) // 플레이어가 오른쪽에 있는경우
            {
                targetPos.y += 1; // 위로 이동

                if (isOddRow)
                {
                    targetPos.x += Random.Range(0, 2) == 0 ? 1 : 0;
                }
                else
                {
                    targetPos.x -= Random.Range(0, 2) == 0 ? 1 : 0;
                }

            }
            else // playerPos.y < thisObjPos.y, 플레이어가 왼쪽에 있는 경우 
            {
                targetPos.y -= 1; // 더 왼쪽으로 이동
                
                if (isOddRow)
                {
                    targetPos.x += Random.Range(0, 2) == 0 ? 1 : 0;

                }
                else
                {
                    targetPos.x -= Random.Range(0, 2) == 0 ? 1 : 0;

                }

            }
        }

        SettargetPos(thisObjPos,playerPos,ref targetPos); // 참조자로 실제 변수값도 변경. 
        Debug.Log($"이동할 위치 : {targetPos.x}, {targetPos.y},{targetPos.z}");
        //MoveCell은 월드좌표 기반이기 때문에, 월드좌표로 변경해주어야 함. 기존 MovePath에서는 미리 변경해서 보내줬지만, 여기선 그런게 없었음.
        Vector3 thisObjworldPos = tilemap.CellToWorld(targetPos);
        Vector3 targetworldPos = tilemap.CellToWorld(targetPos);
        StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, thisObjworldPos, targetworldPos)); // this.gameObject는 이 스크립트가 부착된 객체를 참조
                                                                                                                       // 코루틴 호출
        thisObjPos = tilemap.WorldToCell(transform.position);

        Debug.Log($"현재 위치 : {thisObjPos}");
        yield return null;
    }
}
