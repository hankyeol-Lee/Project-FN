using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps;
using System;
using static Enemy_Behaviour;

public delegate IEnumerator CoroutineDelegate(EnemyState state);

public class Enemy_Behaviour : MonoBehaviour
{
    public Transform playertransform; // �÷��̾��� ��ġ�� ����
    public Tilemap tilemap;
    public GameObject gamemanager;

    // EnemyState ������ ����
    public enum EnemyState
    {
        Wait,
        Move,
        Attack
    };

    // ���� ������ ���� �̺�Ʈ
    private EnemyState _enemystate; // ���� ���� ����
    public CoroutineDelegate OnStateChanged;

    private EnemyState enemystate
    {
        get { return _enemystate; }
        set
        {
            if (_enemystate != value)
            {
                if (OnStateChanged != null)
                {
                    StartCoroutine(OnStateChanged(value));  // null üũ �߰�
                }
                else
                {
                    Debug.LogWarning("OnStateChanged�� null�Դϴ�.");
                }

                _enemystate = value;
                Debug.Log($"10. ���κ��� : {_enemystate}");
            }
        }
    }



    private void Awake()
    {
        // ���� ���� �̺�Ʈ �ڵ鷯 ���
        OnStateChanged = HandleStateChanged;
        Debug.Log("1. �ڵ鷯 �Լ� ���");

    }

    private IEnumerator Start()
    {
        // ���¸� Wait�� �����ϰ� ��� ���
        enemystate = EnemyState.Wait;
        Debug.Log($"3. enemySTATE�� wait���� ���� ��. {enemystate}");

        // Wait ���¿��� �ణ�� ���
        yield return new WaitForSeconds(1f);

        // ���¸� Move�� �����Ͽ� �̺�Ʈ Ʈ����
        enemystate = EnemyState.Move;
        Debug.Log($"11. enemySTATE�� Move���� ���� ��. {enemystate}");
    }


    // ���°� ����Ǿ��� �� ȣ��Ǵ� �Լ�
    private IEnumerator HandleStateChanged(EnemyState newState)
    {
        if (newState == EnemyState.Move)
        {
            Debug.Log($"4 �̺�Ʈ�ڵ鷯�� newstate : {newState}");

            Debug.Log("5. move�� ��ȯ��. �ڷ�ƾ����!");
            MoveToPlayerCell();
            // ���⿡ ���� ���� ���� state�� wait���� �ٲٵ���.
            Debug.Log("9. �� ��������");
            yield return null;
            //MoveToPlayerCellCoroutine(); // ���°� Move�� ����Ǹ� �̵� �ڷ�ƾ ����
        }
        if (newState == EnemyState.Wait)
        {
            Debug.Log($"2. �̺�Ʈ �ڵ鷯�� newState : {newState}");
            yield return null;
        }
    }

    // �÷��̾� ��ġ�� �̵��ϴ� �ڷ�ƾ
    public void MoveToPlayerCell()
    {
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position); // �÷��̾��� Ÿ�ϸ� ��ǥ
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position); // ���� ���� Ÿ�ϸ� ��ǥ
        Vector3Int targetPos = thisObjPos; // �̵� ��ǥ Ÿ�ϸ� ��ǥ �ʱ�ȭ

        Debug.Log($"6. �÷��̾� ��ġ: {playerPos}, ���� ���� ��ġ: {thisObjPos}");

        // �÷��̾� �������� �̵� ��ǥ�� �����ϰ� Ÿ�� ��ȿ���� ����
        Vector3Int GetValidTargetPos(Vector3Int currentPos, Vector3Int targetPos)
        {
            // �÷��̾� �������� �̵� �ĺ� ����
            List<Vector3Int> possibleMoves = new List<Vector3Int>
        {
            new Vector3Int(currentPos.x + 1, currentPos.y, 0),   // ������
            new Vector3Int(currentPos.x - 1, currentPos.y, 0),   // ����
            new Vector3Int(currentPos.x, currentPos.y + 1, 0),   // ����
            new Vector3Int(currentPos.x, currentPos.y - 1, 0),   // �Ʒ���
        };

            // �ĺ� ��ġ�� �Ÿ� �������� ����
            possibleMoves.Sort((a, b) =>
                Vector3Int.Distance(a, targetPos).CompareTo(Vector3Int.Distance(b, targetPos)));

            // Ÿ�ϸ� �󿡼� ��ȿ�� ��ġ ��ȯ
            foreach (var move in possibleMoves)
            {
                if (tilemap.HasTile(move)) // Ÿ�ϸʿ� Ÿ���� �ִ��� Ȯ��
                {
                    return move;
                }
            }

            // ��ȿ�� ��ġ�� ������ ���� ��ġ ��ȯ
            return currentPos;
        }

        // ��ǥ ��ġ ���
        targetPos = GetValidTargetPos(thisObjPos, playerPos);
        Debug.Log($"7. �̵��� ��ġ: {targetPos}");

        // Ÿ�ϸ� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 targetWorldPos = tilemap.CellToWorld(targetPos);

        // �̵� �ڷ�ƾ ȣ��
        StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, transform.position, targetWorldPos));
    }
}

