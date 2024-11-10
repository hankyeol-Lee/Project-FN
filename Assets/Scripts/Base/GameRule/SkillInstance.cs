using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActiveSkillList;

public class SkillInstance : MonoBehaviour
{
    public static Dictionary<string, ActiveSkill> skillInstances = new Dictionary<string, ActiveSkill>(); // 스킬을 저장하는 Active Skill 생성. 

    private void Start()
    {
        InitializeSkills();
    }
    private void InitializeSkills()
    {
        // Resources 폴더에서 모든 SkillData를 불러와서 인스턴스 생성
        SkillData[] allSkillData = Resources.LoadAll<SkillData>("SkillData");
        if (allSkillData != null)
        {
            Debug.Log("제대로 불러옴");
        }        
        else
        {
            Debug.Log("제대로 못불러옴");
        }
        foreach (var data in allSkillData)
        {
            // 스킬 이름에 따라 새로운 ActiveSkill 인스턴스 생성
            if (data.skillName == "MagicBullet")
            {
                skillInstances[data.skillName] = new MagicBullet(data);
                Debug.Log($"{skillInstances[data.skillName]}생성 성공");
            }
            // 다른 스킬도 추가 가능
            // else if (data.skillName == "Fireball") { skillInstances[data.skillName] = new Fireball(data); }
        }
        }
 }

