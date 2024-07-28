using TMPro;
using UnityEngine;
using GameSkill;

public class Description_Change : MonoBehaviour
{
    public TextMeshProUGUI description;

    private void OnEnable()
    {
        SkillHoverEvent.OnSkillHover += UpdateDescription;
    }

    private void Awake()
    {
        description = GetComponentInChildren<TextMeshProUGUI>(); // 자식 객체 변수 할당.
    }

    private void UpdateDescription(Skill skill)
    {
        if (skill != null)
        {
            description.text = skill.Description;
            description.color = Color.black;
            description.fontSize = 18;
        }
        else
        {
            description.text = "";
        }
    }
}
