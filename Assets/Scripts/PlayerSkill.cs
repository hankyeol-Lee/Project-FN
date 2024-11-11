using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;
using UnityEditor.Experimental.GraphView;
using static ActiveSkillList;


public class PlayerSkill : MonoBehaviour
{
    //1, 플레이어 스킬을 저장할 배열 생성
    //2. 플레이어 스킬 추가 메소드, 삭제 메소드 

    public ActiveSkill[] playerSkills = new ActiveSkill[5]; //1.

    public Dictionary<string, ActiveSkill> allSkillLists;

    private void Awake()
    {
        allSkillLists = SkillInstance.skillInstances; // SkillInstance의 딕셔너리를 가져옴
        Debug.Log("playerskill : allskillList 가져옴");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("인스턴스생성함");
            AddSkill("MagicBullet",0);
            Debug.Log("스킬추가함.");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }

    public void AddSkill(string skillName, int slotnum)
    {
        // allSkillLists에서 스킬을 찾아본다
        if (allSkillLists.TryGetValue(skillName, out ActiveSkill skillToAdd))
        {
            // 해당 슬롯이 비어 있는지 확인
            if (playerSkills[slotnum] != null)                                                          
            {
                Debug.LogWarning($"{slotnum + 1}번 슬롯에 이미 스킬이 존재합니다. 다른 슬롯을 선택하거나 스킬을 제거하세요.");
            }
            else
            {
                // 빈 슬롯이면 스킬을 할당
                playerSkills[slotnum] = skillToAdd;
                Debug.Log($"{skillToAdd.skillName} 스킬이 {slotnum + 1}번 슬롯에 할당되었습니다.");
            }
        }
        else
        {
            Debug.LogWarning($"{skillName}이라는 이름의 스킬이 없습니다. 스킬 이름을 확인하세요.");
        }
    }

}
