using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ToastMessage : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static ToastMessage Instance { get; private set; }

    public Text toastText;  // UI Text ������Ʈ
    public float displayTime = 4.0f;  // �ؽ�Ʈ ǥ�� �ð�

    public string message = "";
    private void Awake()
    {
        // �̱��� �ʱ�ȭ
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �ؽ�Ʈ�� ǥ���ϴ� �޼���
    public void ShowMessage()
    {
        toastText.text = message;  // �޽��� ����
        StartCoroutine(DisplayToast());
    }

    // �ڷ�ƾ���� �޽����� ǥ�� �� �����
    private IEnumerator DisplayToast()
    {
        yield return new WaitForSeconds(2f);
        toastText.gameObject.SetActive(true);  // �ؽ�Ʈ Ȱ��ȭ
        yield return new WaitForSeconds(displayTime);  // ���� �ð� ���
        toastText.gameObject.SetActive(false);  // �ؽ�Ʈ ��Ȱ��ȭ
    }
}
