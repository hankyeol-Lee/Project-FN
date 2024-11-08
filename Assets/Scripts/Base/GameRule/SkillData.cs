using GameSkill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static ActiveSkill;

[CreateAssetMenu(fileName = "EnemySkillData", menuName ="SkillData")]
public class SkillData : ScriptableObject // ActiveSkill.cs�� �ִ� �������� ���⿡ ������ ��.
{
    public string skillName;
    public float coefficient; // ��ų ���
    public string displayString;
    public int enemyCastTime;
    public int playerCastTime;
    public int coolDown;
    public int playerCost;
    public int distance; // ��ų ��Ÿ�
    public bool isTargetCell; // ������ O, X�� boolean
    public skillType skilltype; // ��ų�� type�� �����ϴ°�.

    public Tile tile; // Tile prefab�� ���� �����������.

    public List<Vector3Int> SkillRangeList; // ��� ��ǥ�� �� ��ų�� ���� ����Ʈ
    public Vector3Int offset; // ��ų ������ �߰��� ������

}