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
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        Vector3Int targetPos = thisObjPos; // Ÿ�� ������ ����

        Debug.Log($"6. �÷��̾� ��ġ: {playerPos}, ���� ���� ��ġ: {thisObjPos}");

        // �̵��� Ÿ�� ������ ����
        void SettargetPos(Vector3Int thisObjPos, Vector3Int playerPos, ref Vector3Int targetPos)
        {
            bool isOddRow = Mathf.Abs(thisObjPos.y % 2) == 1; // Ȧ�� ������ Ȯ��
            bool isPlayerOnRight = playerPos.y > thisObjPos.y; // �÷��̾ �� �����ʿ� �ִ��� �Ǵ�

            if (playerPos.y == thisObjPos.y) // ���� �࿡ �ִ� ���
            {
                targetPos.x += (playerPos.x > thisObjPos.x) ? 1 : -1; // �÷��̾ �����̸� +1, �ƴϸ� -1
            }
            else if (isPlayerOnRight) // �÷��̾ �����ʿ� �ִ� ���
            {
                targetPos.y += 1;
                if (isOddRow) 
                {
                    targetPos.x += UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0; 
                }
                else
                {
                    targetPos.x -= UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
            }
            else // �÷��̾ ���ʿ� �ִ� ���
            {
                targetPos.y -= 1;

                if (isOddRow)
                {
                    targetPos.x += UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;

                }
                else
                {
                    targetPos.x -= UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }

            }
        }

        // ��ǥ ��ġ ���
        SettargetPos(thisObjPos, playerPos, ref targetPos);
        Debug.Log($"7. �̵��� ��ġ: {targetPos}");

        // Ÿ�ϸ� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 thisObjworldPos = tilemap.CellToWorld(targetPos);
        Vector3 targetworldPos = tilemap.CellToWorld(targetPos);

        thisObjPos = tilemap.WorldToCell(transform.position); // ���� ��ġ ����

        Debug.Log($"8. ���� ��ġ: {thisObjPos}");

        //new WaitForSecondsRealtime(1.0f);
        StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, thisObjworldPos, targetworldPos));
        // �̵� �ڷ�ƾ ȣ��
        

    }
}
