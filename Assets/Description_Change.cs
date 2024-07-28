using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using GameSkill;

public class Description_Change : MonoBehaviour
{
    //마우스가 호버링 한 스킬의 정보를 받아 이 자식객체 텍스트를 변경함.
    // 활성화 되었을 뿐만 아니라 마우스의 호버링한 스킬이 바뀔때도 작동해야함. 내장함수 IPointerEnterHandler 사용
    public TextMeshProUGUI description;
    public GameObject[] BattleUI_Name; // 감지할 이름 객체 배열. 
    private void Awake()
    {
        description = GetComponentInChildren<TextMeshProUGUI>(); // 자식객체 변수 할당. 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("호버링 ok");
        GameObject nametag = eventData.pointerEnter;
        // 이게 스킬 호버링한건지 아이템 호버링한건지 아는거 필요함. 두개의 객체를 만들던가 아니면 다른 매개변수를 주거나 해야함.
        if (nametag != null && IsPredefined(nametag)) // 그리고 battleui_name 배열 안에 있다면
        {
            Skill skill = nametag.GetComponent<SkillDisplay>().thisskill; // 호버링한 객체의 스킬 가져옴.
            if (skill != null)
            {
                description.text = skill.Description;
                description.color = Color.black;
                description.fontSize = 18;
            }
            //nametag의 thisskill 변수를 체크
            // 가져옴

        }
    }
    private bool IsPredefined(GameObject hoveredObj)
    {
        foreach (var name in BattleUI_Name)
        {
            if (hoveredObj == name) {return true;}
        }
        return false;
    }
}
