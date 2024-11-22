using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandButton : MonoBehaviour
{
    [SerializeField] private GameObject baseInventory; // 4칸 인벤토리
    [SerializeField] private GameObject expandedInventory; // 24칸 확장 인벤토리

    public void OnExpandButtonClick()
    {
        Debug.Log("Expand Button Clicked"); // 디버그 메시지로 확인
        baseInventory.SetActive(false); // 4칸 인벤토리 비활성화
        expandedInventory.SetActive(true); // 24칸 인벤토리 활성화

        // 슬롯 갱신
        InventoryManager.Instance.FreshSlot();
    }

    public void OnCloseButtonClick()
    {
        Debug.Log("Close Button Clicked!"); // 디버그 메시지로 확인

        expandedInventory.SetActive(false); // 24칸 인벤토리 비활성화
        baseInventory.SetActive(true); // 4칸 인벤토리 활성화
    }
}
