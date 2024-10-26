using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps; // 타일맵 이동을 위한 hexclass 네임스페이스 사용
public class Enemy_Behaviour : MonoBehaviour
{
    // TODO : Timer 코드에서 사용할 수 있는 행동 함수 설계. 종류 : 이동, 공격

    public Transform playertransform; // 플레이어의 위치를 참조할 수 있게, 전역변수 선언.
    public Tilemap tilemap;
    public GameManager gamemanager;


    public void MoveToPlayerCell() //
    {
        //설계 : 플레이어와의 거리를 계산해서 왼쪽 오른쪽 위 아래를 계산하고 / 왼쪽이라면 칸이 두개가 있는데, 어떻게 함 ?>> 랜덤으로 그 칸으로 움직임
        //이동 로직은 GameManager_Move 에 있는 함수를 사용. 하지만 문제는 거리 계산은 누가함? >> 일단 이 메소드에서 하자.
        //타이머가 함수를 실행하고 다시 타이머가 작동해야 하는데, 그 순서는 ? >> 타이머에서 코루틴을 걸음
        
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        
        if (playerPos.y < thisObjPos.y) // 플레이어가 더 왼쪽에 있을 경우
        {
            //에너미는 왼쪽으로 이동.주의:path를 신경쓸 필요 없음. 
            int randomvalue = Random.Range(0, 2); // 0과 1 중 하나 선택

            if (randomvalue == 0) // 왼쪽 위로 이동.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x += 1;
                targetPos.y -= 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
            else //왼쪽 아래로 이동.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.y -= 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
        }
        else if (playerPos.y > thisObjPos.y) //더 오른쪽에 있을 경우 
        {
            //에너미는 오른쪽으로 이동.주의:path를 신경쓸 필요 없음. 
            int randomvalue = Random.Range(0, 2); // 0과 1 중 하나 선택

            if (randomvalue == 0) // 오른쪽 위로 이동.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x += 1;
                targetPos.y += 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
            else //오른쪽 아래로 이동.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.y += 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
        }
        else // x 좌표가 같은 경우.
        {
            if (playerPos.x > thisObjPos.x) // 플레이어가 더 위에 있을경우
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x += 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
            else
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x -= 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
        }

    }

}
