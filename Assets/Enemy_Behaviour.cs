using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps;
using JetBrains.Annotations;
using System.Runtime.CompilerServices; // Ÿ�ϸ� �̵��� ���� hexclass ���ӽ����̽� ���
public class Enemy_Behaviour : MonoBehaviour
{
    public Transform playertransform; // �÷��̾��� ��ġ�� ������ �� �ְ�, �������� ����.
    public Tilemap tilemap;
    public GameObject gamemanager; // gamemanager���� �ϴ��� empty go�� ��������.

    private void Start()
    {
        InvokeRepeating("MoveToPlayerCellCoroutine", 0f, 2.0f); // InvokeRepeat�� �̿��ؼ� �ڷ�ƾ�� �ݺ� ����(������ string�̶� ������.)
    }

    public void MoveToPlayerCellCoroutine()
    {
        StartCoroutine(MoveToPlayerCell());
    }
    public IEnumerator MoveToPlayerCell() //
    {
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        Vector3Int targetPos = thisObjPos; // Ÿ�� ������ ����

        Debug.Log($"�÷��̾���ġ : {playerPos}, �� ��ġ : {thisObjPos}");

        // �̵� ������ �����ؾ���.


        void SettargetPos(Vector3Int thisObjPos, Vector3Int playerPos, ref Vector3Int targetPos)
        {
            // 1. ���� ���� Ȧ������ ¦������ üũ
            bool isOddRow = Mathf.Abs(thisObjPos.y % 2) == 1; // true�̸� Ȧ�� ��, false�̸� ¦�� ��
           

            // 2. �÷��̾ �� �����ʿ� �ִ���, �� ���ʿ� �ִ��� �Ǵ�
            bool isPlayerOnRight = playerPos.y > thisObjPos.y;

            // 3. y ��ǥ�� ������ ��� x ��ǥ �񱳷� �̵� (���ηθ� �����̴� ���)
            if (playerPos.y == thisObjPos.y)
            {
                // x ��ǥ ��
                if (playerPos.x > thisObjPos.x) // �÷��̾ �� ���� ������
                {
                    targetPos.x += 1; // �ö����
                }
                else
                {
                    targetPos.x -= 1; // �ƴϸ� ��������.
                }
            }
            else if (isPlayerOnRight) // �÷��̾ �����ʿ� �ִ°��
            {
                targetPos.y += 1; // ���� �̵�

                if (isOddRow)
                {
                    targetPos.x += Random.Range(0, 2) == 0 ? 1 : 0;
                }
                else
                {
                    targetPos.x -= Random.Range(0, 2) == 0 ? 1 : 0;
                }

            }
            else // playerPos.y < thisObjPos.y, �÷��̾ ���ʿ� �ִ� ��� 
            {
                targetPos.y -= 1; // �� �������� �̵�
                
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

        SettargetPos(thisObjPos,playerPos,ref targetPos); // �����ڷ� ���� �������� ����. 
        Debug.Log($"�̵��� ��ġ : {targetPos.x}, {targetPos.y},{targetPos.z}");
        //MoveCell�� ������ǥ ����̱� ������, ������ǥ�� �������־�� ��. ���� MovePath������ �̸� �����ؼ� ����������, ���⼱ �׷��� ������.
        Vector3 thisObjworldPos = tilemap.CellToWorld(targetPos);
        Vector3 targetworldPos = tilemap.CellToWorld(targetPos);
        StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, thisObjworldPos, targetworldPos)); // this.gameObject�� �� ��ũ��Ʈ�� ������ ��ü�� ����
                                                                                                                       // �ڷ�ƾ ȣ��
        thisObjPos = tilemap.WorldToCell(transform.position);

        Debug.Log($"���� ��ġ : {thisObjPos}");
        yield return null;
    }
}
