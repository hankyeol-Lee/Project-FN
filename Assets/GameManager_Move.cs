using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager_Move : MonoBehaviour
{
    public string cellTag = "Cell";
    public Tilemap tilemap;
    public TileBase tile;

    private void Update()
    {
        GetRayCell();
    }

    public void GetRayCell() // ��Ŭ���� �ϸ�, ���콺 ��ġ�� �ִ� Ÿ���� �������� �Լ�
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
            }

        }
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

}