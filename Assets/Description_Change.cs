using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using GameSkill;

public class Description_Change : MonoBehaviour
{
    //���콺�� ȣ���� �� ��ų�� ������ �޾� �� �ڽİ�ü �ؽ�Ʈ�� ������.
    // Ȱ��ȭ �Ǿ��� �Ӹ� �ƴ϶� ���콺�� ȣ������ ��ų�� �ٲ𶧵� �۵��ؾ���. �����Լ� IPointerEnterHandler ���
    public TextMeshProUGUI description;
    public GameObject[] BattleUI_Name; // ������ �̸� ��ü �迭. 
    private void Awake()
    {
        description = GetComponentInChildren<TextMeshProUGUI>(); // �ڽİ�ü ���� �Ҵ�. 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ȣ���� ok");
        GameObject nametag = eventData.pointerEnter;
        // �̰� ��ų ȣ�����Ѱ��� ������ ȣ�����Ѱ��� �ƴ°� �ʿ���. �ΰ��� ��ü�� ������� �ƴϸ� �ٸ� �Ű������� �ְų� �ؾ���.
        if (nametag != null && IsPredefined(nametag)) // �׸��� battleui_name �迭 �ȿ� �ִٸ�
        {
            Skill skill = nametag.GetComponent<SkillDisplay>().thisskill; // ȣ������ ��ü�� ��ų ������.
            if (skill != null)
            {
                description.text = skill.Description;
                description.color = Color.black;
                description.fontSize = 18;
            }
            //nametag�� thisskill ������ üũ
            // ������

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
