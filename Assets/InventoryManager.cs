using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // �̱��� ����

    public List<Relic> relics = new List<Relic>(); // ���� ����Ʈ

    // InvBase ���� ����
    [Header("Base Inventory Settings")]
    [SerializeField]
    private Transform baseSlotParent; // InvBase�� ItemSlots
    [SerializeField]
    private ItemSlot[] baseSlots; // InvBase ���� �迭

    // ExpandedInv ���� ����
    [Header("Expanded Inventory Settings")]
    [SerializeField]
    private Transform expandedSlotParent; // ExpandedInv�� ExInvSlot
    [SerializeField]
    private ItemSlot[] expandedSlots; // ExpandedInv ���� �迭

#if UNITY_EDITOR
    private void OnValidate()
    {
        // �����Ϳ��� �ڵ����� ���� �迭 ����
        if (baseSlotParent != null)
            baseSlots = baseSlotParent.GetComponentsInChildren<ItemSlot>();

        if (expandedSlotParent != null)
            expandedSlots = expandedSlotParent.GetComponentsInChildren<ItemSlot>();
    }
#endif

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        FreshSlot(); // �ʱ� ���� ����
    }

    public void FreshSlot()
    {
        // Base Inventory ����
        int i = 0;
        for (; i < relics.Count && i < baseSlots.Length; i++)
        {
            baseSlots[i].SetRelic(relics[i]); // ���Կ� ���� ������ ����
        }


        // Expanded Inventory ����
        for (int j = 0; j < expandedSlots.Length; j++)
        {
            if (i < relics.Count)
            {
                expandedSlots[j].SetRelic(relics[i]); // Ȯ�� ���Կ� ���� ������ ����
                i++;
            }

        }
    }

public void AddRelicToInventory(string relicName)
{
    // RelicManager���� ���� ������ �˻�
    RelicManager.Instance.AddRelic(relicName);
    Relic relic = RelicManager.Instance.activeRelics.Find(r => r.Name == relicName);

    if (relic != null && !relics.Contains(relic)) // �ߺ� ����
    {

        relics.Add(relic);
        Debug.Log($"[AddRelicToInventory] Relic added: {relic.Name}");
        Debug.Log($"Description: {relic.Description}");
        Debug.Log($"Sprite: {(relic.Image != null ? relic.Image.name : "No Image Found")}");

        FreshSlot(); // UI ����
    }
    else
    {
        Debug.LogWarning($"[AddRelicToInventory] Failed to add relic: {relicName}");
        Debug.Log($"Reason: {(relic == null ? "Relic not found in RelicManager" : "Relic already in inventory")}");
    }
}


    private void Start()
    {
        // ����: �κ��丮�� ���� �߰�
        AddRelicToInventory("Amber");
        AddRelicToInventory("Diamond");
        AddRelicToInventory("Sapphire");
    }
}
