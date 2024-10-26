using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexClass;
using UnityEngine.Tilemaps; // Ÿ�ϸ� �̵��� ���� hexclass ���ӽ����̽� ���
public class Enemy_Behaviour : MonoBehaviour
{
    // TODO : Timer �ڵ忡�� ����� �� �ִ� �ൿ �Լ� ����. ���� : �̵�, ����

    public Transform playertransform; // �÷��̾��� ��ġ�� ������ �� �ְ�, �������� ����.
    public Tilemap tilemap;
    public GameManager gamemanager;


    public void MoveToPlayerCell() //
    {
        //���� : �÷��̾���� �Ÿ��� ����ؼ� ���� ������ �� �Ʒ��� ����ϰ� / �����̶�� ĭ�� �ΰ��� �ִµ�, ��� �� ?>> �������� �� ĭ���� ������
        //�̵� ������ GameManager_Move �� �ִ� �Լ��� ���. ������ ������ �Ÿ� ����� ������? >> �ϴ� �� �޼ҵ忡�� ����.
        //Ÿ�̸Ӱ� �Լ��� �����ϰ� �ٽ� Ÿ�̸Ӱ� �۵��ؾ� �ϴµ�, �� ������ ? >> Ÿ�̸ӿ��� �ڷ�ƾ�� ����
        
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int thisObjPos = tilemap.WorldToCell(transform.position);
        
        if (playerPos.y < thisObjPos.y) // �÷��̾ �� ���ʿ� ���� ���
        {
            //���ʹ̴� �������� �̵�.����:path�� �Ű澵 �ʿ� ����. 
            int randomvalue = Random.Range(0, 2); // 0�� 1 �� �ϳ� ����

            if (randomvalue == 0) // ���� ���� �̵�.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x += 1;
                targetPos.y -= 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
            else //���� �Ʒ��� �̵�.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.y -= 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
        }
        else if (playerPos.y > thisObjPos.y) //�� �����ʿ� ���� ��� 
        {
            //���ʹ̴� ���������� �̵�.����:path�� �Ű澵 �ʿ� ����. 
            int randomvalue = Random.Range(0, 2); // 0�� 1 �� �ϳ� ����

            if (randomvalue == 0) // ������ ���� �̵�.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x += 1;
                targetPos.y += 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
            else //������ �Ʒ��� �̵�.
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.y += 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
        }
        else // x ��ǥ�� ���� ���.
        {
            if (playerPos.x > thisObjPos.x) // �÷��̾ �� ���� �������
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x += 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
            else
            {
                Vector3Int targetPos = thisObjPos;
                targetPos.x -= 1;
                gamemanager.GetComponent<GameManager_Move>().MoveCell(thisObjPos, targetPos);
            }
        }

    }

}
