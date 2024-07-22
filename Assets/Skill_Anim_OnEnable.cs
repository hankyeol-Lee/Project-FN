using System.Collections;
using UnityEngine;

public class Skill_Anim_OnEnable : MonoBehaviour
{
    private float duration = 0.1f; // �̵��ð�

    private Vector2 targetPosition = new Vector2(23, 127); // ��ǥ ��ġ (UI ��ǥ)
    private float targetRotation = 12.646f; // ��ǥ ȸ�� (Z�� ȸ��)

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

            // ���� ���� (t^2)
            float nonlinearT = Mathf.Pow(t, 2);

            // UI ��ǥ�� ��ġ ����
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, nonlinearT);
            // Z�� ȸ�� ����
            float currentRotation = Mathf.Lerp(startRotation, targetRotation, nonlinearT);
            rectTransform.localEulerAngles = new Vector3(0, 0, currentRotation);

            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        rectTransform.localEulerAngles = new Vector3(0, 0, targetRotation);
    }
}
