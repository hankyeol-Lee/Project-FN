using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // �̱��� �������� ����
    public List<Item> items = new List<Item>(); // ���� ������ ����Ʈ

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
        // �����Ϳ��� �ڵ����� ���� �迭�� ����
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

        FreshSlot(); // ���� �ʱ�ȭ
    }

    public void FreshSlot()
    {
        // Base Inventory ����
        int i = 0;
        for (; i < items.Count && i < baseSlots.Length; i++)
        {
            baseSlots[i].item = items[i]; // ������ �Ҵ�
        }
        for (; i < baseSlots.Length; i++)
        {
            baseSlots[i].item = null; // ������ ���� ����
        }

        // Expanded Inventory ����
        for (int j = 0; j < expandedSlots.Length; j++)
        {
            if (i < items.Count)
            {
                expandedSlots[j].item = items[i]; // ���� ������ Ȯ�� ���Կ� �Ҵ�
                i++;
            }
            else
            {
                expandedSlots[j].item = null; // ���� ����
            }
        }
    }

    public void AddItem(Item _item)
    {
        if (items.Count < baseSlots.Length + expandedSlots.Length) // ��ü ���� üũ
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("������ ���� á���ϴ�.");
        }
    }
    void Start(){
        AddItem(ItemDatabaseSingleton.Instance.GetItemByName("Amber"));
        AddItem(ItemDatabaseSingleton.Instance.GetItemByName("Diamond"));
        AddItem(ItemDatabaseSingleton.Instance.GetItemByName("Sapphire"));

    }
}
