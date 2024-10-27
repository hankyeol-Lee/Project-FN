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
                StartCoroutine(OnStateChanged(value)); // enemystate�� setter�� �־ �ɵ�?
                _enemystate = value;
                Debug.Log($"���κ��� : {_enemystate}");
            }
        }
    }


    private void Awake()
    {
        // ���� ���� �̺�Ʈ �ڵ鷯 ���
        OnStateChanged = HandleStateChanged;
        Debug.Log("�ڵ鷯 �Լ� ���");

    }

    private void Start()
    {
        // ���¸� Move�� �����Ͽ� �̺�Ʈ Ʈ����
        enemystate = EnemyState.Wait;
        Debug.Log("wait�ҰԿ��");
        //StartCoroutine(OnStateChanged(EnemyState.Move)); // enemystate�� setter�� �־ �ɵ�?
        enemystate = EnemyState.Move;
    }

    // ���°� ����Ǿ��� �� ȣ��Ǵ� �Լ�
    private IEnumerator HandleStateChanged(EnemyState newState)
    {
        Debug.Log($"newstate : {newState}");
        if (newState == EnemyState.Move)
        {
            Debug.Log("move�� ��ȯ��. �ڷ�ƾ����!");
            yield return StartCoroutine(MoveToPlayerCell());
            // ���⿡ ���� ���� ���� state�� wait���� �ٲٵ���.
            Debug.Log("�� ��������");

            //MoveToPlayerCellCoroutine(); // ���°� Move�� ����Ǹ� �̵� �ڷ�ƾ ����
        }
    }

    // �÷��̾� ��ġ�� �̵��ϴ� �ڷ�ƾ
    public IEnumerator MoveToPlayerCell()
    {
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        Vector3Int targetPos = thisObjPos; // Ÿ�� ������ ����

        Debug.Log($"�÷��̾� ��ġ: {playerPos}, ���� ���� ��ġ: {thisObjPos}");

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
        Debug.Log($"�̵��� ��ġ: {targetPos}");

        // Ÿ�ϸ� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 thisObjworldPos = tilemap.CellToWorld(targetPos);
        Vector3 targetworldPos = tilemap.CellToWorld(targetPos);

        thisObjPos = tilemap.WorldToCell(transform.position); // ���� ��ġ ����

        Debug.Log($"���� ��ġ: {thisObjPos}");

        new WaitForSecondsRealtime(1.0f);
        yield return StartCoroutine(gamemanager.GetComponent<GameManager_Move>().MoveCell(this.gameObject, thisObjworldPos, targetworldPos));
        // �̵� �ڷ�ƾ ȣ��
        

    }
}
