using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.PackageManager;
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
    internal int distance; // ��ų ��Ÿ�
    internal bool isTargetCell; // ������ O, X�� boolean
    internal skillType skilltype; // ��ų�� type�� �����ϴ°�.
    internal static Tile newTile;

    internal List<Vector3Int> skillRange; // TODO : �̰� � ������� ��������. ��ų ������ �����ϴ� ����Ʈ

    public enum skillType
    {
        Physics,
        Magic,
        Alteration
    }

    public abstract void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell);

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

    //showRange : ��ų ������ �����ִ� �޼ҵ�. �̰� � ������ ��ų ĭ�� ������ �� �𸣁���.
    public void ShowRange()
    {
        if (skillRange != null)
        {
            foreach (var cell in skillRange)
            {
                GameManager.Instance.tilemap.SetTile(cell, newTile);
                Debug.Log($"��ų���� {newTile} ������");
            }
        }
        else
        {
            Debug.Log("��ų ������ ���� �ȵǾ�����");
        }
    }


}
