using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using GameSkill;

public class SkillDisplay : MonoBehaviour
{
    public Skill thisskill = null;
    public Text skillDisplay = null;
    // Start is called before the first frame update
    public void GetSkillInfo(Skill skill)
    {
        thisskill = skill; // ��ų ����.
        //��ų �̸� �����ִ� �ڵ�
        skillDisplay.text = skill.DisplayString;
        skillDisplay.color = Color.black;
        skillDisplay.fontSize = 18;
    }
}
