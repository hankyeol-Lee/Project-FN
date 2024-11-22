using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallInv : MonoBehaviour
{
    private void Start()
    {
        // InventoryManager�� FreshSlot ȣ��
        InventoryManager.Instance.FreshSlot();
    }

    public void AddItemToSharedInventory(Item item)
    {
        InventoryManager.Instance.AddItem(item); // �߾� ������ ���� ����Ʈ�� �߰�
    }
}

