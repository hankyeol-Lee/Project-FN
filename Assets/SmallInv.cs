using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallInv : MonoBehaviour
{
    private void Start()
    {
        // InventoryManager의 FreshSlot 호출
        InventoryManager.Instance.FreshSlot();
    }

    public void AddItemToSharedInventory(Item item)
    {
        InventoryManager.Instance.AddItem(item); // 중앙 아이템 관리 리스트에 추가
    }
}

