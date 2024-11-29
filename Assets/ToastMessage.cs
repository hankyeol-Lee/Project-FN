using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ToastMessage : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static ToastMessage Instance { get; private set; }

    public Text toastText;  // UI Text 오브젝트
    public float displayTime = 4.0f;  // 텍스트 표시 시간

    public string message = "";
    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 텍스트를 표시하는 메서드
    public void ShowMessage()
    {
        toastText.text = message;  // 메시지 설정
        StartCoroutine(DisplayToast());
    }

    // 코루틴으로 메시지를 표시 후 숨기기
    private IEnumerator DisplayToast()
    {
        yield return new WaitForSeconds(2f);
        toastText.gameObject.SetActive(true);  // 텍스트 활성화
        yield return new WaitForSeconds(displayTime);  // 일정 시간 대기
        toastText.gameObject.SetActive(false);  // 텍스트 비활성화
    }
}
