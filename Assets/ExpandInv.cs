using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandInv : MonoBehaviour
{
    private void Start()
    {
        // Ȯ��� �κ��丮�� Ȱ��ȭ�� �� ���� ����
        InventoryManager.Instance.FreshSlot();
    }
}



