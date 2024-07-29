using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using GameSkill;
using TMPro;
using UnityEngine.EventSystems;

public class SkillDisplay : MonoBehaviour, IPointerEnterHandler
{
    public Skill thisSkill = null;
    public TextMeshProUGUI skillDisplay = null;
    // Start is called before the first frame update
    public void GetSkillInfo(Skill skill)
    {
        Debug.Log("함수 실행까지도 ok");
        if (skillDisplay == null)
        {
            skillDisplay = GetComponentInChildren<TextMeshProUGUI>();
        }
        thisSkill = skill; // 스킬 저장.
        Debug.Log("스킬 저장까지도 OK");
        //스킬 이름 보여주는 코드
        if (skillDisplay != null)
        {
            skillDisplay.text = skill.DisplayString;
            skillDisplay.color = Color.black;
            skillDisplay.fontSize = 18;
        }
        
    }
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillHoverEvent.TriggerSkillHover(thisSkill);
    }

    
    

}
