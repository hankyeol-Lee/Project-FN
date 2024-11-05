using GameSkill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySkillData", menuName ="SkillData")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public string description;
    public float damage;
    public int cost;
    public int range;
    public string displayString;

    public Skill ToSkill() // scriptabledata�� skill Ŭ������ instance�� ��ȯ.
    {
        return new Skill(skillName, description, damage, cost, range, displayString);
    }
}