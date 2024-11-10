using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActiveSkillList;

public class SkillInstance : MonoBehaviour
{
    public static Dictionary<string, ActiveSkill> skillInstances = new Dictionary<string, ActiveSkill>(); // ��ų�� �����ϴ� Active Skill ����. 

    private void Start()
    {
        InitializeSkills();
    }
    private void InitializeSkills()
    {
        // Resources �������� ��� SkillData�� �ҷ��ͼ� �ν��Ͻ� ����
        SkillData[] allSkillData = Resources.LoadAll<SkillData>("SkillData");
        if (allSkillData != null)
        {
            Debug.Log("����� �ҷ���");
        }        
        else
        {
            Debug.Log("����� ���ҷ���");
        }
        foreach (var data in allSkillData)
        {
            // ��ų �̸��� ���� ���ο� ActiveSkill �ν��Ͻ� ����
            if (data.skillName == "MagicBullet")
            {
                skillInstances[data.skillName] = new MagicBullet(data);
                Debug.Log($"{skillInstances[data.skillName]}���� ����");
            }
            // �ٸ� ��ų�� �߰� ����
            // else if (data.skillName == "Fireball") { skillInstances[data.skillName] = new Fireball(data); }
        }
        }
 }

