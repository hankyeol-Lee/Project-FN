using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;

public class SkillPanel_Anim_Fade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.2f;
    private float targetalpha = 1f;

    public GameObject[] skillChildren;
    // Start is called before the first frame update
    private void Awake()
    {
        canvasGroup = canvasGroup ?? GetComponent<CanvasGroup>();
        if (canvasGroup == null) // 없다면 새로 추가
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        canvasGroup = canvasGroup ?? GetComponent<CanvasGroup>();
        if (canvasGroup == null) // 없다면 새로 추가
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        StartCoroutine(FadeIn());
        SkillActivate();
    }
    private void SkillActivate()
    {
        // 자식객체를 선볋해서 active하기 vs public 한 판때기 배열을 미리 만들고 foreach로 선별하기 . 일단은 후자로
        //다시 선별하기 위해 전부 다시 끄기
        foreach (var child in skillChildren)
        {
            child.SetActive(false);
        }
        // 플레이어의 스킬 목록을 받아옴.
        PlayerSkill playerSkillList = GameManager.Instance.player.GetComponent<PlayerSkill>();

        //활성화할 스킬창 찾기. 근데 순서대로 되어야하니 stack 자료구조 사용해야할듯. 추후 수정 요망
        for (int i = 0; i < 5; i++)
        {
            ActiveSkill skill = playerSkillList.playerSkills[i]; //n번 칸에 스킬이 있다 -> n번째 childrenskill을 활성화.
            //SkillDisplay skillDisplay = skillChildren[i].GetComponent<SkillDisplay>();
            //Debug.Log(skillDisplay);
            if (skill != null)
            {
                skillChildren[i].SetActive(true);
                //Debug.Log("여기까지는 ok");
                //skillChildren[i].GetComponent<SkillDisplay>().GetSkillInfo(skill);
                //skillDisplay.GetSkillInfo(skill);

            }
        }
    }
    private void OnDisable() // 없어질 때도 하는건 이 코드 이전에 해야함.
    {
        canvasGroup = canvasGroup ?? GetComponent<CanvasGroup>();
        if (canvasGroup == null) // 없다면 새로 추가
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        //StopAllCoroutines();
        canvasGroup.alpha = 0f;
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.77f);
        float elapsedtime = 0f;
        while (elapsedtime < fadeDuration)
        {
            elapsedtime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedtime / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = targetalpha;
    }
    
}
