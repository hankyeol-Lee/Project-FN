using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;

public class SkillHoverEvent : MonoBehaviour // 스킬 호버링 이벤트 생성.
{
    public static event Action<Skill> OnSkillHover;

    public static void TriggerSkillHover(Skill skill) //
    {
        if (OnSkillHover != null)
        {
            OnSkillHover(skill); //스킬창을 호버링하면 이벤트 실행,
        }
    }
}
