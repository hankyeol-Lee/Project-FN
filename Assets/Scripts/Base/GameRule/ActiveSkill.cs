using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Enemyspace;
using Microsoft.Unity.VisualStudio.Editor;
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
    internal int distance; // 사거리. 스킬 키를 누르면 표시되는 스킬 원형 모양의 반지름.
    internal int skillcelldist; // 스킬 각각의 사거리. 예를 들어서, 사거리가 1이면 중앙 한 셀인거고 사거리가 2이면 중앙 셀을 기준으로 2칸까지의 셀 
    internal Sprite skillIcon;
    internal bool isTargetCell; // 셀지정 O, X의 boolean
    internal skillType skilltype; // 스킬의 type을 지정하는거.

    private Tile newTile;


    private Dictionary<Vector3Int, TileBase> previousSkillTiles = new Dictionary<Vector3Int, TileBase>();


    internal List<Vector3Int> skillRange; // TODO : 이거 어떤 방식으로 설정할지. 적용되는 스킬 범위 셀을 저장하는 리스트

    public enum skillType
    {
        Physics,
        Magic,
        Alteration
    }

    public abstract void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell);
    public abstract void CastSkill(ActiveSkill useSkill,GameObject skillCaster);

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
            skillcelldist = data.skillcelldist;
            skillIcon = data.skillIcon;
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

    //showdistance : 스킬 범위를 보여주는 메소드. 이걸 어떤 식으로 스킬 칸을 관리할 지 모르곘음.
    public void ShowRange(Vector3Int mouseCellPos)
    {
        Tilemap tilemap = GameManager.Instance.tilemap;
        //GameManager.Instance.skillHexRadius.ScaleHex(mouseCellPos,this.skillcelldist);

        int distance = skillcelldist;

        // 이전 스킬 범위 타일을 원래 상태로 복원
        foreach (var cell in previousSkillTiles.Keys)
        {
            tilemap.SetTile(cell, previousSkillTiles[cell]);
        }
        previousSkillTiles.Clear(); // 초기화 후 딕셔너리 비우기
        skillRange.Clear(); // 새로운 스킬 범위 계산 전 초기화

        // 범위 내 셀 계산
        Vector3Int centerCell = mouseCellPos;
        for (int x = -distance; x <= distance; x++)
        {
            for (int y = -distance; y <= distance; y++)
            {
                if (Mathf.Abs(x + y) <= distance)
                {
                    Vector3Int offset = new Vector3Int(x,y, 0);
                    Vector3Int cell = centerCell + offset;
                    skillRange.Add(cell);

                    // 기존 타일을 저장하여 나중에 복원 가능하게 함
                    if (!previousSkillTiles.ContainsKey(cell))
                    {
                        previousSkillTiles[cell] = tilemap.GetTile(cell);
                    }
                }
            }
        }
        // 새로운 범위 타일 설정
        foreach (var cell in skillRange)
        {
            tilemap.SetTile(cell, newTile);
            //Debug.Log($"스킬범위 {cell} 에 지정됨");
        }
    }

    public List<GameObject> CheckRangeEnemy(Vector3Int mouseCellPos)
    {
        Tilemap tilemap = GameManager.Instance.tilemap;
        List<GameObject> enemyList = new List<GameObject>();

        int distance = skillcelldist;
        skillRange.Clear(); // 계산 전 초기화

        // 범위 내 셀 계산
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
