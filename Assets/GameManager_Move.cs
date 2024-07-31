using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager_Move : MonoBehaviour
{
    public string cellTag = "Cell";
    public Tilemap tilemap;
    public TileBase tile;
    public GameObject player;


    private Vector3Int targetPos;


    private void Update()
    {
        targetPos = GetRayCell(); // 
    }

    Vector3Int GetRayCell() // 우클릭을 하면, 마우스 위치에 있는 타일을 가져오는 함수
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("ray 쐈어");

            RaycastHit2D[] hit = Physics2D.GetRayIntersectionAll(ray); //ray를 받은 '모든' 객체를 hit 변수에 저장.
            Debug.Log("hit에 넣었어");
            Vector3Int? returnCell = CheckCell(hit); //받아온 셀


            //받아온 셀의 좌표 출력 및 settile로 이미지 변경.
            if (returnCell.HasValue)
            {
                Vector3Int TargetCell = returnCell.Value;
                Debug.Log($"타겟셀 : {TargetCell}");
                tilemap.SetTile(TargetCell, tile);
                return TargetCell;
            }

            //a star algorithm으로 경로 찾기,
            Vector3Int playerpos = GetPlayerPos();
            Vector3Int[] onway = null;




        }
        return targetPos;
    }


    Vector3Int? CheckCell(RaycastHit2D[] hit) //ray hit에서 cell만 걸러내는 함수. cell은 단 하나여야함.
    {
        foreach (var cell in hit)
        {
            if (cell.collider.CompareTag(cellTag)) // cellTag랑 똑같으면.
            {
                Vector3 worldPosition = cell.point;
                Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
                Debug.Log($"리턴 셀좌표 : {cellPosition}");
                return cellPosition;
            }
        }
        return null;
    }
    Vector3Int GetPlayerPos()
    {
        Vector3Int playercellpos = tilemap.WorldToCell(player.transform.position);
        Debug.Log($"플레이어 셀 좌표 : {playercellpos}");
        return playercellpos;
    }
}