using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using GameSkill;
using TMPro;

public class SkillDisplay : MonoBehaviour
{
    public Skill thisskill = null;
    public TextMeshProUGUI skillDisplay = null;
    // Start is called before the first frame update
    public void GetSkillInfo(Skill skill)
    {
        Debug.Log("�Լ� ��������� ok");
        if (skillDisplay == null)
        {
            skillDisplay = GetComponentInChildren<TextMeshProUGUI>();
        }
        thisskill = skill; // ��ų ����.
        Debug.Log("��ų ��������� OK");
        //��ų �̸� �����ִ� �ڵ�
        if (skillDisplay != null)
        {
            skillDisplay.text = skill.DisplayString;
            skillDisplay.color = Color.black;
            skillDisplay.fontSize = 18;
        }
        
    }
}
