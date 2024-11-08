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
        if (canvasGroup == null) // ���ٸ� ���� �߰�
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        canvasGroup = canvasGroup ?? GetComponent<CanvasGroup>();
        if (canvasGroup == null) // ���ٸ� ���� �߰�
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        StartCoroutine(FadeIn());
        SkillActivate();
    }
    private void SkillActivate()
    {
        // �ڽİ�ü�� �����ؼ� active�ϱ� vs public �� �Ƕ��� �迭�� �̸� ����� foreach�� �����ϱ� . �ϴ��� ���ڷ�
        //�ٽ� �����ϱ� ���� ���� �ٽ� ����
        foreach (var child in skillChildren)
        {
            child.SetActive(false);
        }
        // �÷��̾��� ��ų ����� �޾ƿ�.
        PlayerSkill playerSkillList = GameManager.Instance.player.GetComponent<PlayerSkill>();

        //Ȱ��ȭ�� ��ųâ ã��. �ٵ� ������� �Ǿ���ϴ� stack �ڷᱸ�� ����ؾ��ҵ�. ���� ���� ���
        for (int i = 0; i < 5; i++)
        {
            ActiveSkill skill = playerSkillList.playerSkills[i]; //n�� ĭ�� ��ų�� �ִ� -> n��° childrenskill�� Ȱ��ȭ.
            //SkillDisplay skillDisplay = skillChildren[i].GetComponent<SkillDisplay>();
            //Debug.Log(skillDisplay);
            if (skill != null)
            {
                skillChildren[i].SetActive(true);
                //Debug.Log("��������� ok");
                //skillChildren[i].GetComponent<SkillDisplay>().GetSkillInfo(skill);
                //skillDisplay.GetSkillInfo(skill);

            }
        }
    }
    private void OnDisable() // ������ ���� �ϴ°� �� �ڵ� ������ �ؾ���.
    {
        canvasGroup = canvasGroup ?? GetComponent<CanvasGroup>();
        if (canvasGroup == null) // ���ٸ� ���� �߰�
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
