using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.VFX;

public abstract class ActiveSkill // 사용할 스킬을 지정한
{

    // 아래는 SkillData에서 ScriptableObject로 지정할 것들.
    internal string skillName;
    internal float coefficient;
    internal int enemyCastTime;
    internal int playerCastTime;
    internal int coolDown;
    internal int playerCost;
    internal int distance; // 스킬 사거리
    internal bool isTargetCell; // 셀지정 O, X의 boolean
    internal skillType skilltype; // 스킬의 type을 지정하는거.
    internal static Tile newTile;

    internal List<Vector3Int> skillRange; // TODO : 이거 어떤 방식으로 설정할지. 스킬 범위를 저장하는 리스트

    public enum skillType
    {
        Physics,
        Magic,
        Alteration
    }

    public abstract void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell);

    public abstract void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget); // 타겟 대상 스킬 오버로딩
    public ActiveSkill(SkillData data) // 생성자 : SkillData를 객체가 component로 받아서, 그 값을 할당해줌.
    {
        try
        {
            skillName = data.skillName; // 변수 초기화하고, 추가로 스킬 범위 셀에 넣어야하는것도 ㅇㅇ
            coefficient = data.coefficient;
            enemyCastTime = data.enemyCastTime;
            playerCastTime = data.playerCastTime;
            coolDown = data.coolDown;
            playerCost = data.playerCost;
            distance = data.distance;
            isTargetCell = data.isTargetCell;
            skilltype = data.skilltype;
            newTile = data.tile;
            skillRange = new List<Vector3Int>(); // 리스트 초기화
    }
        catch (NullReferenceException)
        {
            Debug.Log("제대로 할당 안됨.");
        }
    }

    public float returnSkillDamage() // 데미지 계산식을 전역으로 구현해서, 스킬 데미지를 반환하는 메소드
    {
        return 0.0f;
    }


    public void SetSkillRangeCell ()
    {

    }

    //showRange : 스킬 범위를 보여주는 메소드. 이걸 어떤 식으로 스킬 칸을 관리할 지 모르곘음.
    public void ShowRange()
    {
        if (skillRange != null)
        {
            foreach (var cell in skillRange)
            {
                GameManager.Instance.tilemap.SetTile(cell, newTile);
                Debug.Log($"스킬범위 {newTile} 지정됨");
            }
        }
        else
        {
            Debug.Log("스킬 범위가 지정 안되어있음");
        }
    }


}
