using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Data", menuName = "Enemy Data")] // Enemy�� ���� ������ �ϳ��� data type ����.
public class EnemyData : ScriptableObject
{
    public string Name; // �̸�. 
    public float HP;
    public float AD;
    public float AP;
    public int AR; // ��������. 
    public int MR; // Magic Resistance, �������׷�.
    public float Speed;

    public List<SkillData> skills; // ���� ������ ��ų ����Ʈ.    
}

