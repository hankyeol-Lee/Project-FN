using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;
using static ActiveSkillList;


public class PlayerSkill : MonoBehaviour
{
    //1, �÷��̾� ��ų�� ������ �迭 ����
    //2. �÷��̾� ��ų �߰� �޼ҵ�, ���� �޼ҵ� 

    public ActiveSkill[] playerSkills = new ActiveSkill[5]; //1.

    public Dictionary<string, ActiveSkill> allSkillLists;

    private void Awake()
    {
        allSkillLists = SkillInstance.skillInstances; // SkillInstance�� ��ųʸ��� ������
    }

    private void Start()
    {
        AddSkill("MagicBullet", 0);
        AddSkill("Flame", 1);
        AddSkill("GhostlyGrasp", 2);
        AddSkill("Decay", 3);
    }
    

    public void AddSkill(string skillName, int slotnum)
    {
        // allSkillLists���� ��ų�� ã�ƺ���
        if (allSkillLists.TryGetValue(skillName, out ActiveSkill skillToAdd))
        {
            // �ش� ������ ��� �ִ��� Ȯ��
            if (playerSkills[slotnum] != null)                                                          
            {
                Debug.LogWarning($"{slotnum + 1}�� ���Կ� �̹� ��ų�� �����մϴ�. �ٸ� ������ �����ϰų� ��ų�� �����ϼ���.");
            }
            else
            {
                // �� �����̸� ��ų�� �Ҵ�
                playerSkills[slotnum] = skillToAdd;
                SkillUIBase.Instance.setSkilIcon(slotnum,skillToAdd);
                Debug.Log($"{skillToAdd.skillName} ��ų�� {slotnum + 1}�� ���Կ� �Ҵ�Ǿ����ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning($"{skillName}�̶�� �̸��� ��ų�� �����ϴ�. ��ų �̸��� Ȯ���ϼ���.");
        }
    }

}
