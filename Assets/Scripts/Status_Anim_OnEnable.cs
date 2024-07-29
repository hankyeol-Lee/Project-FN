using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Anim_OnEnable : MonoBehaviour
{
    private float duration = 0.5f; // �̵��ð�
    private Vector2 targetPosition = new Vector2(-229.97f, 146); // ��ǥ ��ġ (UI ��ǥ)

    private RectTransform rectTransform;
    private Vector2 initialPosition; // �ʱ� ��ġ�� ������ ����

    public GameObject StatusPanel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition; // �ʱ� ��ġ ����
        //gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // rectTransform�� ��ġ�� �ʱ� ��ġ�� ����
        rectTransform.anchoredPosition = initialPosition;
    }

    public void OnStatusClick_Move(bool isClicked)
    {
        if (isClicked)
        {
            StopAllCoroutines();
            StartCoroutine(Status_Anim_MoveBack());
            //�̰� ������, ���� �ʱ� ui�� ���ƿ�
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Status_Anim_Move());
            //�� �ڷ�ƾ�� ������, ��ų �Ƕ��⸦ �ҷ����� �ڵ带 ����

        }

    }

    IEnumerator Status_Anim_Move()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // ���� ���� (t^2)
            float nonlinearT = Mathf.Pow(t, 2);

            // UI ��ǥ�� ��ġ ����
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, nonlinearT);

            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        yield return new WaitForSeconds(0.77f);

        //�� �ڷ�ƾ�� ������, ��ų �Ƕ��⸦ �ҷ����� �ڵ带 ����
        StatusPanel.SetActive(true);
    }

    IEnumerator Status_Anim_MoveBack()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // ���� ���� (t^2)
            float nonlinearT = Mathf.Pow(t, 2);

            // UI ��ǥ�� ��ġ ����
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, initialPosition, nonlinearT);

            yield return null;
        }

        rectTransform.anchoredPosition = initialPosition;
    }
}
