using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using HexClass;
using TMPro;
using System.IO;

public class GameManager_Move : MonoBehaviour
{
    public string cellTag = "Cell";
    public Tilemap tilemap;
    //public TileBase tile;
    public GameObject player;

    private Vector3Int targetCell;
    public TileBase highlightTile; // ������ Ÿ��
    public Vector3Int playerCellPos;

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
            tilemap.SetTile(neighborPos, highlightTile); // �̿� ���� ���� Ÿ�� ����
        }
    }

    private void GetRayCell() // ��Ŭ���� �ϸ�, ���콺 ��ġ�� �ִ� Ÿ���� �������� �Լ�
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
                //tilemap.SetTile(targetCell, tile);
                List<Vector3Int> playerPath = HexClass.HexPathfinding.FindPath(playerCellPos, targetCell, obstacles);
                //Debug.Log($"�÷��̾��� �� ��ǥ : {playerCellPos}");
                //Debug.Log($"���콺�� Ŭ���� ���� ��ǥ : {targetCell}");
                // ��� ����� ���
                Debug.Log("��� ���:");
                foreach (var step in playerPath)
                {
                    Debug.Log(step);
                }
                StartCoroutine(MovePath(playerPath));
                
            }
        }
    }


    Vector3Int? CheckCell(RaycastHit2D[] hit) // ray hit���� cell�� �ɷ����� �Լ�. cell�� �� �ϳ����� ��.
    {
        foreach (var cell in hit)
        {
            if (cell.collider.CompareTag(cellTag)) // cellTag�� ��ġ�ϸ�
            {
                Vector3 worldPosition = cell.point;
                Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
                //Debug.Log($"���� ����ǥ : {cellPosition}");
                return cellPosition;
            }
        }
        return null;
    }

    Vector3Int GetPlayerPos()
    {
        Vector3Int playerCellPos = tilemap.WorldToCell(player.transform.position);
        //Debug.Log($"�÷��̾� �� ��ǥ : {playerCellPos}");
        return playerCellPos;
    }

    IEnumerator MovePath(List<Vector3Int> path)
    {
        foreach (var cell in path)
        {
            playerCellPos = GetPlayerPos();
            Vector3 startWorldPos = tilemap.CellToWorld(playerCellPos); // �÷��̾ �ִ� ���� ���߾� ��ǥ�� ������. 
            Vector3 endWorldPos = tilemap.CellToWorld(cell); // cell. �� ���� ���� �߾���ǥ�� ������.
            //Debug.DrawLine(startWorldPos, endWorldPos);
            yield return MoveCell(startWorldPos, endWorldPos);
        }
    }


    public IEnumerator MoveCell(Vector3 startWorldPos, Vector3 endWorldPos)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            player.transform.position = Vector3.Lerp(startWorldPos, endWorldPos, t);
            yield return null; 
        }

        // ��Ȯ�� ��ǥ ��ġ�� ����
        player.transform.position = endWorldPos;
        //Debug.Log("�÷��̾� ��ġ�� �� �߽ɿ� �����߽��ϴ�.");
    }
}