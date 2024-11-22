using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandInv : MonoBehaviour
{
    private void Start()
    {
        // 확장된 인벤토리가 활성화될 때 슬롯 갱신
        InventoryManager.Instance.FreshSlot();
    }
}



