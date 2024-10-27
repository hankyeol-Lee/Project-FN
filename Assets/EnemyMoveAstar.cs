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

        // ���� �̵� ���� ���� ��θ� ����
        if (!enemymoving)
        {
            enemymoving = true;
            // �� ��ο� ���� �̵� �ڷ�ƾ ����
        }
        else // �����̰� ���� ����� ���ο� ��� ����.
        {
            //StopAllCoroutines();
            playerPos = tilemap.WorldToCell(playertransform.position);
            thisObjPos = tilemap.WorldToCell(transform.position) ;
        }
        Debug.Log($"���� ��ġ : {thisObjPos}");
        Debug.Log($"���� �����̴� ���� : {enemymoving}");
        enemypath = HexClass.HexPathfinding.FindPath(thisObjPos,  playerPos, obstacles);
        Debug.Log("�� ã�Ҿ��");
        StartCoroutine(EnemyMovePath(enemypath));

    }

    IEnumerator EnemyMovePath(List<Vector3Int> path)
    {
        Vector3 startWorldPos;
        Vector3 endWorldPos;

        // ��θ� ���� �̵�
        foreach (var cell in path)
        {
            startWorldPos = tilemap.CellToWorld(tilemap.WorldToCell(transform.position)); // ���� ��ġ
            endWorldPos = tilemap.CellToWorld(cell); // ��ǥ ��ġ

            // ���� ��ǥ ��ġ�� �̵�
            yield return StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, startWorldPos, endWorldPos));

            // �� �� �̵� �� ��� ���
            yield return new WaitForSeconds(1.0f);
        }

        enemymoving = false;  // �̵� �Ϸ� �� �̵� ���� ���·� ����
    }
}
