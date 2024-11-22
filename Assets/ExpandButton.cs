using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandButton : MonoBehaviour
{
    [SerializeField] private GameObject baseInventory; // 4ĭ �κ��丮
    [SerializeField] private GameObject expandedInventory; // 24ĭ Ȯ�� �κ��丮

    public void OnExpandButtonClick()
    {
        Debug.Log("Expand Button Clicked"); // ����� �޽����� Ȯ��
        baseInventory.SetActive(false); // 4ĭ �κ��丮 ��Ȱ��ȭ
        expandedInventory.SetActive(true); // 24ĭ �κ��丮 Ȱ��ȭ

        // ���� ����
        InventoryManager.Instance.FreshSlot();
    }

    public void OnCloseButtonClick()
    {
        Debug.Log("Close Button Clicked!"); // ����� �޽����� Ȯ��

        expandedInventory.SetActive(false); // 24ĭ �κ��丮 ��Ȱ��ȭ
        baseInventory.SetActive(true); // 4ĭ �κ��丮 Ȱ��ȭ
    }
}
