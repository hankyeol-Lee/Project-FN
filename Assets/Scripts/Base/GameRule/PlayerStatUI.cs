using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour
{
    // Start is called before the first frame update    public TextMeshProUGUI statsText; // UI TextMeshPro ������Ʈ
    // public Text statsText; // �⺻ Text ������Ʈ�� ����ϴ� ��� �� ���� Ȱ��ȭ
    public Text statsText; // UI TextMeshPro ������Ʈ
    // public Text statsText; // �⺻ Text ������Ʈ�� ����ϴ� ��� �� ���� Ȱ��ȭ

    private void Update()
    {
        // �÷��̾� ���¸� ������ �ؽ�Ʈ ������Ʈ
        statsText.text = $"HP: {PlayerStatus.Instance.playerHP:F1}\n" +
                         $"AD: {PlayerStatus.Instance.playerAD:F1}\n" +
                         $"AP: {PlayerStatus.Instance.playerAP:F1}\n" +
                         $"AR: {PlayerStatus.Instance.playerAR:F1}\n" +
                         $"MR: {PlayerStatus.Instance.playerMR:F1}";
    }
}
