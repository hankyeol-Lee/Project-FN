using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour
{
    // Start is called before the first frame update    public TextMeshProUGUI statsText; // UI TextMeshPro 컴포넌트
    // public Text statsText; // 기본 Text 컴포넌트를 사용하는 경우 이 줄을 활성화
    public Text statsText; // UI TextMeshPro 컴포넌트
    // public Text statsText; // 기본 Text 컴포넌트를 사용하는 경우 이 줄을 활성화

    private void Update()
    {
        // 플레이어 상태를 가져와 텍스트 업데이트
        statsText.text = $"HP: {PlayerStatus.Instance.playerHP:F1}\n" +
                         $"AD: {PlayerStatus.Instance.playerAD:F1}\n" +
                         $"AP: {PlayerStatus.Instance.playerAP:F1}\n" +
                         $"AR: {PlayerStatus.Instance.playerAR:F1}\n" +
                         $"MR: {PlayerStatus.Instance.playerMR:F1}";
    }
}
