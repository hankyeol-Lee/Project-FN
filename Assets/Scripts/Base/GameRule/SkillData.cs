using GameSkill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static ActiveSkill;

[CreateAssetMenu(fileName = "EnemySkillData", menuName ="SkillData")]
public class SkillData : ScriptableObject // ActiveSkill.cs에 있는 변수들을 여기에 넣으면 됨.
{
    public string skillName;
    public float coefficient; // 스킬 계수
    public string displayString;
    public int enemyCastTime;
    public int playerCastTime;
    public int coolDown;
    public int playerCost;
    public int distance; // 스킬 사거리
    public bool isTargetCell; // 셀지정 O, X의 boolean
    public skillType skilltype; // 스킬의 type을 지정하는거.

    public Tile tile; // Tile prefab을 만들어서 적용해줘야함.

    public List<Vector3Int> SkillRangeList; // 상대 좌표로 각 스킬의 범위 리스트
    public Vector3Int offset; // 스킬 범위에 추가할 오프셋

}