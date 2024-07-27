using System.Collections;
using UnityEngine;

public class Skill_Anim_OnEnable : MonoBehaviour
{
    private float duration = 0.5f; // 이동시간
    private Vector2 targetPosition = new Vector2(-229.97f, 146); // 목표 위치 (UI 좌표)

    private RectTransform rectTransform;
    private Vector2 initialPosition; // 초기 위치를 저장할 변수

    public GameObject SkillPanel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition; // 초기 위치 저장
        //gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // rectTransform의 위치를 초기 위치로 복원
        rectTransform.anchoredPosition = initialPosition;
    }

    public void OnSkillClick_Move(bool isClicked)
    {
        if (isClicked)
        {
            StopAllCoroutines();
            StartCoroutine(Skill_Anim_MoveBack());
            //이게 끝나면, 원래 초기 ui로 돌아옴
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Skill_Anim_Move());
            //이 코루틴이 끝나면, 스킬 판때기를 불러오는 코드를 실행
        }
        
    }

    IEnumerator Skill_Anim_Move()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // 비선형 보간 (t^2)
            float nonlinearT = Mathf.Pow(t, 2);

            // UI 좌표로 위치 변경
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, nonlinearT);

            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;

        SkillPanel.SetActive(true);


    }

    IEnumerator Skill_Anim_MoveBack()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // 비선형 보간 (t^2)
            float nonlinearT = Mathf.Pow(t, 2);

            // UI 좌표로 위치 변경
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, initialPosition, nonlinearT);

            yield return null;
        }

        rectTransform.anchoredPosition = initialPosition;
    }
}