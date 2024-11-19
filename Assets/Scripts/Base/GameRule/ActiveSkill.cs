using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.VFX;

public abstract class ActiveSkill // ����� ��ų�� ������
{

    // �Ʒ��� SkillData���� ScriptableObject�� ������ �͵�.
    internal string skillName;
    internal float coefficient;
    internal int enemyCastTime;
    internal int playerCastTime;
    internal int coolDown;
    internal int playerCost;
    internal int distance; // ��Ÿ�. ��ų Ű�� ������ ǥ�õǴ� ��ų ���� ����� ������.
    internal int skillcelldist; // ��ų ������ ��Ÿ�. ���� ��, ��Ÿ��� 1�̸� �߾� �� ���ΰŰ� ��Ÿ��� 2�̸� �߾� ���� �������� 2ĭ������ �� 

    internal bool isTargetCell; // ������ O, X�� boolean
    internal skillType skilltype; // ��ų�� type�� �����ϴ°�.
    internal static Tile newTile;

    private Dictionary<Vector3Int, TileBase> previousSkillTiles = new Dictionary<Vector3Int, TileBase>();


    internal List<Vector3Int> skillRange; // TODO : �̰� � ������� ��������. ����Ǵ� ��ų ���� ���� �����ϴ� ����Ʈ

    public enum skillType
    {
        Physics,
        Magic,
        Alteration
    }

    public abstract void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell);
    public abstract void CastSkill(ActiveSkill useSkill,GameObject skillCaster);

    public abstract void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget); // Ÿ�� ��� ��ų �����ε�
    public ActiveSkill(SkillData data) // ������ : SkillData�� ��ü�� component�� �޾Ƽ�, �� ���� �Ҵ�����.
    {
        try
        {
            skillName = data.skillName; // ���� �ʱ�ȭ�ϰ�, �߰��� ��ų ���� ���� �־���ϴ°͵� ����
            coefficient = data.coefficient;
            enemyCastTime = data.enemyCastTime;
            playerCastTime = data.playerCastTime;
            coolDown = data.coolDown;
            playerCost = data.playerCost;
            distance = data.distance;
            isTargetCell = data.isTargetCell;
            skilltype = data.skilltype;
            newTile = data.tile;
            skillRange = new List<Vector3Int>(); // ����Ʈ �ʱ�ȭ
            skillcelldist = data.skillcelldist;
    }
        catch (NullReferenceException)
        {
            Debug.Log("����� �Ҵ� �ȵ�.");
        }
    }

    public float returnSkillDamage() // ������ ������ �������� �����ؼ�, ��ų �������� ��ȯ�ϴ� �޼ҵ�
    {
        return 0.0f;
    }


    public void SetSkillRangeCell ()
    {

    }

    //showdistance : ��ų ������ �����ִ� �޼ҵ�. �̰� � ������ ��ų ĭ�� ������ �� �𸣁���.
    public void ShowRange(Vector3Int mouseCellPos)
    {
        Tilemap tilemap = GameManager.Instance.tilemap;
        //GameManager.Instance.skillHexRadius.ScaleHex(mouseCellPos,this.skillcelldist);

        int distance = skillcelldist;

        // ���� ��ų ���� Ÿ���� ���� ���·� ����
        foreach (var cell in previousSkillTiles.Keys)
        {
            tilemap.SetTile(cell, previousSkillTiles[cell]);
        }
        previousSkillTiles.Clear(); // �ʱ�ȭ �� ��ųʸ� ����
        skillRange.Clear(); // ���ο� ��ų ���� ��� �� �ʱ�ȭ

        // ���� �� �� ���
        Vector3Int centerCell = mouseCellPos;
        for (int x = -distance; x <= distance; x++)
        {
            for (int y = -distance; y <= distance; y++)
            {
                if (Mathf.Abs(x + y) <= distance)
                {
                    Vector3Int offset = new Vector3Int(y, x, 0);
                    Vector3Int cell = centerCell + offset;
                    skillRange.Add(cell);

                    // ���� Ÿ���� �����Ͽ� ���߿� ���� �����ϰ� ��
                    if (!previousSkillTiles.ContainsKey(cell))
                    {
                        previousSkillTiles[cell] = tilemap.GetTile(cell);
                    }
                }
            }
        }

        // ���ο� ���� Ÿ�� ����
        foreach (var cell in skillRange)
        {
            tilemap.SetTile(cell, newTile);
            Debug.Log($"��ų���� {cell} �� ������");
        }
    }
}
