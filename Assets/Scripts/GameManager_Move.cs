using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using HexClass;
using TMPro;
using System.IO;
using System.Linq;

public class GameManager_Move : MonoBehaviour
{
    public string cellTag = "Cell";
    public Tilemap tilemap;
    //public TileBase tile;
    public GameObject player;

    private Vector3Int targetCell;
    private Vector3Int currentTargetCell; // 현재 플레이어 이동의 목적 타일
    private bool is_P_Moving; // 플레이어가 타일 이동 중인지 판별
    public TileBase highlightTile; // 강조할 타일
    public Vector3Int playerCellPos;

    Animator playeranimator;

    private void Start()
    {
        is_P_Moving = false;
        playeranimator = player.GetComponent<Animator>();
    }
    private void Update()
    {
        GetRayCell();
        /*Vector3Int newPlayerCellPos = GetPlayerPos();
        if (newPlayerCellPos != playerCellPos)
        {
            playerCellPos = newPlayerCellPos;
            //HighlightNeighborCells(playerCellPos);
        }
        */
    }

    public void HighlightNeighborCells(Vector3Int playerCellPos)
    {
        Hex playerHex = new Hex(playerCellPos.x, playerCellPos.y);
        List<Hex> neighbors = playerHex.GetNeighbors();

        foreach (Hex neighbor in neighbors)
        {
            Vector3Int neighborPos = new Vector3Int(neighbor.q, neighbor.r, 0);
            tilemap.SetTile(neighborPos, highlightTile); // 이웃 셀에 강조 타일 설정
        }
    }

    private void GetRayCell() // 우클릭을 하면, 마우스 위치에 있는 타일을 가져오는 함수
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

            Vector3Int? returnCell = CheckCell(hits);
            playerCellPos = GetPlayerPos();

            if (returnCell.HasValue)
            {
                HashSet<Hex> obstacles = new HashSet<Hex>();
                targetCell = returnCell.Value;
                List<Vector3Int> playerPath = new List<Vector3Int>(); 
                //tilemap.SetTile(targetCell, tile);
                //List<Vector3Int> playerPath = HexClass.HexPathfinding.FindPath(playerCellPos, targetCell, obstacles);
                if (! is_P_Moving)
                {
                    playerPath = HexClass.HexPathfinding.FindPath(playerCellPos, targetCell, obstacles); // 이동 중 아니라면 현재 타일부터 playerPath 시작
                    currentTargetCell = targetCell;
                    is_P_Moving = true;
                }
                else
                {
                    playerPath = HexClass.HexPathfinding.FindPath(currentTargetCell, targetCell, obstacles); // 이동 중 이라면 현재 향하는 목적 타일부터 playerPath 시작
          
                }
                //Debug.Log($"플레이어의 셀 좌표 : {playerCellPos}");
                //Debug.Log($"마우스로 클릭한 셀의 좌표 : {targetCell}");
                
                StartCoroutine(MovePath(playerPath));
                
                
            }
        }
    }


    Vector3Int? CheckCell(RaycastHit2D[] hit) // ray hit에서 cell만 걸러내는 함수. cell은 단 하나여야 함.
    {
        foreach (var cell in hit)
        {
            if (cell.collider.CompareTag(cellTag)) // cellTag와 일치하면
            {
                Vector3 worldPosition = cell.point;
                Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
                //Debug.Log($"리턴 셀좌표 : {cellPosition}");
                return cellPosition;
            }
        }
        return null;
    }

    Vector3Int GetPlayerPos()
    {
        Vector3Int playerCellPos = tilemap.WorldToCell(player.transform.position);
        //Debug.Log($"플레이어 셀 좌표 : {playerCellPos}");
        return playerCellPos;
    }

    public IEnumerator MovePath(List<Vector3Int> path)
    {
        playeranimator.Play("PLAYER_MOVE_ANIM");
        foreach (var cell in path)
        {
            playerCellPos = GetPlayerPos();
            Vector3 startWorldPos = tilemap.CellToWorld(playerCellPos); // 플레이어가 있는 셀의 정중앙 좌표를 가져옴. 
            Vector3 endWorldPos = tilemap.CellToWorld(cell); // cell. 즉 다음 셀의 중앙좌표를 가져옴.
            //Debug.DrawLine(startWorldPos, endWorldPos);
            yield return MoveCell(player,startWorldPos, endWorldPos);
        }
        is_P_Moving = false;
        playeranimator.Play("PLAYER_IDLE_ANIM");
    }


    public IEnumerator MoveCell(GameObject mover, Vector3 startWorldPos, Vector3 endWorldPos) // MoveCell 을 수정해서, 플레이어 말고 다른 객체도 움직일 수 있도록.
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

        // 정확히 목표 위치로 설정
        mover.transform.position = endWorldPos;
        //Debug.Log("플레이어 위치가 셀 중심에 도달했습니다.");
    }
}
