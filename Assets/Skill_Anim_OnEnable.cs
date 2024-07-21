using System.Collections;
using UnityEngine;

public class Skill_Anim_OnEnable : MonoBehaviour
{
    private float duration = 0.1f; // 이동시간

    private Vector2 targetPosition = new Vector2(23, 127); // 목표 위치 (UI 좌표)
    private float targetRotation = 12.646f; // 목표 회전 (Z축 회전)

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(Skill_Anim_Move());
    }

    IEnumerator Skill_Anim_Move()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        float startRotation = rectTransform.localEulerAngles.z;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // 비선형 보간 (t^2)
            float nonlinearT = Mathf.Pow(t, 2);

            // UI 좌표로 위치 변경
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, nonlinearT);
            // Z축 회전 변경
            float currentRotation = Mathf.Lerp(startRotation, targetRotation, nonlinearT);
            rectTransform.localEulerAngles = new Vector3(0, 0, currentRotation);

            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        rectTransform.localEulerAngles = new Vector3(0, 0, targetRotation);
    }
}
