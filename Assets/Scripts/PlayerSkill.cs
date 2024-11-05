using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;
using UnityEditor.Experimental.GraphView;


public class PlayerSkill : MonoBehaviour
{
    //1, 플레이어 스킬을 저장할 배열 생성
    //2. 플레이어 스킬 추가 메소드, 삭제 메소드 

    public Skill[] playerSkills = new Skill[5]; //1.

    private void Awake()
    {
        AddSkill(0, "블리자드");
        AddSkill(1,"화염구");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddSkill(0, "블리자드");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddSkill(1, "화염구");
        }
    }

    public void AddSkill(int slotnum, string skillname)
    {
        if (playerSkills[slotnum] != null)
        {
            //이미 있는곳에 스킬 넣기. 한칸 뒤로 미루기 vs 못넣게 하기?
        }
        if (SkillList.SkillDict.TryGetValue(skillname, out Skill skill))
        {
            playerSkills[slotnum] = skill;
            Debug.Log($"{skillname}이 {slotnum+1} 번호에 할당됨.");
        }

    }
}
