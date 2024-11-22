using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 싱글톤 패턴으로 관리
    public List<Item> items = new List<Item>(); // 공통 아이템 리스트

    // InvBase 관련 슬롯
    [Header("Base Inventory Settings")]
    [SerializeField]
    private Transform baseSlotParent; // InvBase의 ItemSlots
    [SerializeField]
    private ItemSlot[] baseSlots; // InvBase 슬롯 배열

    // ExpandedInv 관련 슬롯
    [Header("Expanded Inventory Settings")]
    [SerializeField]
    private Transform expandedSlotParent; // ExpandedInv의 ExInvSlot
    [SerializeField]
    private ItemSlot[] expandedSlots; // ExpandedInv 슬롯 배열

#if UNITY_EDITOR
    private void OnValidate()
    {
        // 에디터에서 자동으로 슬롯 배열을 갱신
        if (baseSlotParent != null)
            baseSlots = baseSlotParent.GetComponentsInChildren<ItemSlot>();

        if (expandedSlotParent != null)
            expandedSlots = expandedSlotParent.GetComponentsInChildren<ItemSlot>();
    }
#endif

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        FreshSlot(); // 슬롯 초기화
    }

    public void FreshSlot()
    {
        // Base Inventory 갱신
        int i = 0;
        for (; i < items.Count && i < baseSlots.Length; i++)
        {
            baseSlots[i].item = items[i]; // 아이템 할당
        }
        for (; i < baseSlots.Length; i++)
        {
            baseSlots[i].item = null; // 나머지 슬롯 비우기
        }

        // Expanded Inventory 갱신
        for (int j = 0; j < expandedSlots.Length; j++)
        {
            if (i < items.Count)
            {
                expandedSlots[j].item = items[i]; // 남은 아이템 확장 슬롯에 할당
                i++;
            }
            else
            {
                expandedSlots[j].item = null; // 슬롯 비우기
            }
        }
    }

    public void AddItem(Item _item)
    {
        if (items.Count < baseSlots.Length + expandedSlots.Length) // 전체 슬롯 체크
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("슬롯이 가득 찼습니다.");
        }
    }
    void Start(){
        AddItem(ItemDatabaseSingleton.Instance.GetItemByName("Amber"));
        AddItem(ItemDatabaseSingleton.Instance.GetItemByName("Diamond"));
        AddItem(ItemDatabaseSingleton.Instance.GetItemByName("Sapphire"));

    }
}
