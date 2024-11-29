using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // �̱��� ����

    public List<Relic> relics = new List<Relic>(); // ���� ����Ʈ

/*
    [Header("Base Inventory Settings")]
    [SerializeField]
    private Transform baseSlotParent; // InvBase�� ItemSlots
    [SerializeField]
    private ItemSlot[] baseSlots; // InvBase ���� �迭
*/
    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Scene ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
        }

    }

    /*private void OnEnable()
    {
        // Scene ��ȯ �̺�Ʈ ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Scene ��ȯ �̺�Ʈ ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // BattleUIScene���� InvBase�� ã�� baseSlotParent�� ����
        if (scene.name == "GamePlayScene") // Scene �̸��� �°� ����
        {
            GameObject invBaseObject = GameObject.Find("InvBase");
            if (invBaseObject != null)
            {
                baseSlotParent = invBaseObject.transform;
                Debug.Log("InvBase�� baseSlotParent�� ����Ǿ����ϴ�.");

                // baseSlots �ʱ�ȭ
                baseSlots = baseSlotParent.GetComponentsInChildren<ItemSlot>();
                Debug.Log($"baseSlots �ʱ�ȭ �Ϸ�: {baseSlots.Length}�� ������ �����Ǿ����ϴ�.");

                // ���� ����
                FreshSlot();
            }
            else
            {
                Debug.LogWarning("InvBase�� ã�� �� �����ϴ�. BattleUIScene�� InvBase�� �ִ��� Ȯ���ϼ���.");
            }
        }
    }
*/
  /*  public void FreshSlot()
    {
        if (baseSlots == null || baseSlotParent == null)
        {
            Debug.LogWarning("Base Slots �Ǵ� Base Slot Parent�� �������� �ʾҽ��ϴ�.");
            return;
        }

        // Base Inventory ����
        int i = 0;
        for (; i < relics.Count && i < baseSlots.Length; i++)
        {
            baseSlots[i].SetRelic(relics[i]); // ���Կ� ���� ������ ����
        }
    }
*/
    public void AddRelicToInventory(string relicName)
    {
        // RelicManager���� ���� ������ �˻�
        Debug.Log($"RelicManager COUNT : {RelicManager.Instance.activeRelics.Count}");
        if (RelicManager.Instance.allRelics.ContainsKey(relicName))
        {
            Relic relic = RelicManager.Instance.allRelics[relicName];
            if (relic != null && !relics.Contains(relic)) // �ߺ� ����
        {
            relics.Add(relic);
            RelicManager.Instance.AddRelic(relicName);
            Debug.Log($"[AddRelicToInventory] Relic added: {relic.Name}");
            Debug.Log($"Description: {relic.Description}");
            Debug.Log($"Sprite: {(relic.Image != null ? relic.Image.name : "No Image Found")}");

            //FreshSlot(); // UI ����
        }

        else
        {
            Debug.LogWarning($"[AddRelicToInventory] Failed to add relic: {relicName}");
            Debug.Log($"Reason: {(relic == null ? "Relic not found in RelicManager" : "Relic already in inventory")}");
        }
        }

    }
}
