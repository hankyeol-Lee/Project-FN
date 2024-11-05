using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;
using UnityEditor.Experimental.GraphView;


public class PlayerSkill : MonoBehaviour
{
    //1, �÷��̾� ��ų�� ������ �迭 ����
    //2. �÷��̾� ��ų �߰� �޼ҵ�, ���� �޼ҵ� 

    public Skill[] playerSkills = new Skill[5]; //1.

    private void Awake()
    {
        AddSkill(0, "���ڵ�");
        AddSkill(1,"ȭ����");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddSkill(0, "���ڵ�");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddSkill(1, "ȭ����");
        }
    }

    public void AddSkill(int slotnum, string skillname)
    {
        if (playerSkills[slotnum] != null)
        {
            //�̹� �ִ°��� ��ų �ֱ�. ��ĭ �ڷ� �̷�� vs ���ְ� �ϱ�?
        }
        if (SkillList.SkillDict.TryGetValue(skillname, out Skill skill))
        {
            playerSkills[slotnum] = skill;
            Debug.Log($"{skillname}�� {slotnum+1} ��ȣ�� �Ҵ��.");
        }

    }
}
