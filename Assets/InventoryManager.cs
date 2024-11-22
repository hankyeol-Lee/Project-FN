using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 싱글톤 패턴

    public List<Relic> relics = new List<Relic>(); // 유물 리스트

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
        // 에디터에서 자동으로 슬롯 배열 갱신
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

        FreshSlot(); // 초기 슬롯 갱신
    }

    public void FreshSlot()
    {
        // Base Inventory 갱신
        int i = 0;
        for (; i < relics.Count && i < baseSlots.Length; i++)
        {
            baseSlots[i].SetRelic(relics[i]); // 슬롯에 유물 데이터 설정
        }


        // Expanded Inventory 갱신
        for (int j = 0; j < expandedSlots.Length; j++)
        {
            if (i < relics.Count)
            {
                expandedSlots[j].SetRelic(relics[i]); // 확장 슬롯에 유물 데이터 설정
                i++;
            }

        }
    }

public void AddRelicToInventory(string relicName)
{
    // RelicManager에서 유물 데이터 검색
    RelicManager.Instance.AddRelic(relicName);
    Relic relic = RelicManager.Instance.activeRelics.Find(r => r.Name == relicName);

    if (relic != null && !relics.Contains(relic)) // 중복 방지
    {

        relics.Add(relic);
        Debug.Log($"[AddRelicToInventory] Relic added: {relic.Name}");
        Debug.Log($"Description: {relic.Description}");
        Debug.Log($"Sprite: {(relic.Image != null ? relic.Image.name : "No Image Found")}");

        FreshSlot(); // UI 갱신
    }
    else
    {
        Debug.LogWarning($"[AddRelicToInventory] Failed to add relic: {relicName}");
        Debug.Log($"Reason: {(relic == null ? "Relic not found in RelicManager" : "Relic already in inventory")}");
    }
}


    private void Start()
    {
        // 예제: 인벤토리에 유물 추가
        AddRelicToInventory("Amber");
        AddRelicToInventory("Diamond");
        AddRelicToInventory("Sapphire");
    }
}
