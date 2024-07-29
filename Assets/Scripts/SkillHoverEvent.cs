using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;

public class SkillHoverEvent : MonoBehaviour // ��ų ȣ���� �̺�Ʈ ����.
{
    public static event Action<Skill> OnSkillHover;

    public static void TriggerSkillHover(Skill skill) //
    {
        if (OnSkillHover != null)
        {
            OnSkillHover(skill); //��ųâ�� ȣ�����ϸ� �̺�Ʈ ����,
        }
    }
}
