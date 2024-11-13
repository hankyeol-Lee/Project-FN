using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Data", menuName = "Enemy Data")] // Enemy의 값을 설정할 하나의 data type 생성.
public class EnemyData : ScriptableObject
{
    public string Name; // 이름. 
    public float HP;
    public float AD;
    public float AP;
    public int AR; // 물리방어력. 
    public int MR; // Magic Resistance, 마법저항력.
    public float Speed;

    public List<SkillData> skills; // 적이 보유한 스킬 리스트.    
}

