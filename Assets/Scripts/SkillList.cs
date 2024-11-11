using System.Collections.Generic;
using UnityEngine;
using GameSkill;

namespace GameSkill
{
    public static class SkillList
    {
        public static readonly Dictionary<string, Skill> SkillDict; // �������� SkillDict�� ��ųʸ� ����

        static SkillList()
        {
            SkillDict = new Dictionary<string, Skill>
        {
            { "ȭ����", new Skill("ȭ����", "��ǥ ������ ȭ������ �߻��� ���� �������� �ݴϴ�.", 5f, 2, 4, "ȭ���� | ������ 5 | Cost 2 | ���� : 4ĭ | ") },
            { "���ڵ�", new Skill("���ڵ�", "��ǥ ������ ��ĭ ������ ���� ���� ������ ������ ���� �������� �ݴϴ�.", 4f, 2, 8, "���ڵ� | ������ 4 | Cost 2 | ���� : 8ĭ") }
        };
        }
    }
}
    
