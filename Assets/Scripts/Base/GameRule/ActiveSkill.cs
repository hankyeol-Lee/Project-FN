using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Enemyspace;
using HexClass;
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
    internal Sprite skillIcon;
    internal bool isTargetCell; // ������ O, X�� boolean
    internal skillType skilltype; // ��ų�� type�� �����ϴ°�.

    private Tile newTile;


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
            skillIcon = data.skillIcon;
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

    public void RecoverCell(Tilemap tilemap)
    {
        // ���� Ÿ�� ����

        if (previousSkillTiles != null)
        {
            foreach (var cell in previousSkillTiles.Keys)
            {
                tilemap.SetTile(cell, previousSkillTiles[cell]);
            }
            previousSkillTiles.Clear();
            skillRange.Clear();
        }
        
    }


    //showdistance : ��ų ������ �����ִ� �޼ҵ�. �̰� � ������ ��ų ĭ�� ������ �� �𸣁���.
    public void ShowRange(Vector3Int mouseCellPos)
    {
        Tilemap tilemap = GameManager.Instance.tilemap;

        RecoverCell(tilemap);

        // �߽� ��
        Hex centerHex = new Hex(mouseCellPos.x, mouseCellPos.y);

        // ��ų ������ ������ HashSet
        HashSet<Hex> rangeSet = new HashSet<Hex>();
        rangeSet.Add(centerHex);

        // ��ų ������ �ܰ躰�� Ȯ��
        for (int i = 0; i < skillcelldist-1; i++)
        {
            // ���� ������ �̿��� ��� �߰�
            HashSet<Hex> neighbors = new HashSet<Hex>();
            foreach (Hex hex in rangeSet)
            {
                neighbors.UnionWith(hex.GetNeighbors(tilemap));
            }
            rangeSet.UnionWith(neighbors); // ���� ���տ� �߰�
        }

        // ���� ������ Vector3Int�� ��ȯ
        foreach (Hex hex in rangeSet)
        {
            Vector3Int cellPos = hex.ToVector3Int();
            skillRange.Add(cellPos);

            // ���� Ÿ�� ����
            if (!previousSkillTiles.ContainsKey(cellPos))
            {
                previousSkillTiles[cellPos] = tilemap.GetTile(cellPos);
            }
        }

        // Ÿ�ϸʿ� ���� ����
        foreach (var cell in skillRange)
        {
            tilemap.SetTile(cell, newTile);
        }
    }




    public List<GameObject> CheckRangeEnemy(Vector3Int mouseCellPos)
    {
        Tilemap tilemap = GameManager.Instance.tilemap;
        List<GameObject> enemyList = new List<GameObject>();

        int distance = skillcelldist;
        skillRange.Clear(); // ��� �� �ʱ�ȭ

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

                }
            }
        }

        foreach(var cell in skillRange)
        {
            Vector3 worldPosition = tilemap.CellToWorld(cell); 
            Collider2D[] hits = Physics2D.OverlapPointAll(worldPosition);

            foreach (var hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    enemyList.Add(hit.gameObject);
                }
            }
        }
        return enemyList;

    }
}
