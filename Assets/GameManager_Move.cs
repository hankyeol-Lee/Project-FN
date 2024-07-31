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

    Vector3Int GetRayCell() // ��Ŭ���� �ϸ�, ���콺 ��ġ�� �ִ� Ÿ���� �������� �Լ�
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("ray ����");

            RaycastHit2D[] hit = Physics2D.GetRayIntersectionAll(ray); //ray�� ���� '���' ��ü�� hit ������ ����.
            Debug.Log("hit�� �־���");
            Vector3Int? returnCell = CheckCell(hit); //�޾ƿ� ��


            //�޾ƿ� ���� ��ǥ ��� �� settile�� �̹��� ����.
            if (returnCell.HasValue)
            {
                Vector3Int TargetCell = returnCell.Value;
                Debug.Log($"Ÿ�ټ� : {TargetCell}");
                tilemap.SetTile(TargetCell, tile);
                return TargetCell;
            }

            //a star algorithm���� ��� ã��,
            Vector3Int playerpos = GetPlayerPos();
            Vector3Int[] onway = null;




        }
        return targetPos;
    }


    Vector3Int? CheckCell(RaycastHit2D[] hit) //ray hit���� cell�� �ɷ����� �Լ�. cell�� �� �ϳ�������.
    {
        foreach (var cell in hit)
        {
            if (cell.collider.CompareTag(cellTag)) // cellTag�� �Ȱ�����.
            {
                Vector3 worldPosition = cell.point;
                Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
                Debug.Log($"���� ����ǥ : {cellPosition}");
                return cellPosition;
            }
        }
        return null;
    }
    Vector3Int GetPlayerPos()
    {
        Vector3Int playercellpos = tilemap.WorldToCell(player.transform.position);
        Debug.Log($"�÷��̾� �� ��ǥ : {playercellpos}");
        return playercellpos;
    }
}