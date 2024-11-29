using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 싱글톤 패턴

    public List<Relic> relics = new List<Relic>(); // 유물 리스트

/*
    [Header("Base Inventory Settings")]
    [SerializeField]
    private Transform baseSlotParent; // InvBase의 ItemSlots
    [SerializeField]
    private ItemSlot[] baseSlots; // InvBase 슬롯 배열
*/
    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Scene 전환 시 유지
        }
        else
        {
            Destroy(gameObject);
        }

    }

    /*private void OnEnable()
    {
        // Scene 전환 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Scene 전환 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // BattleUIScene에서 InvBase를 찾고 baseSlotParent에 연결
        if (scene.name == "GamePlayScene") // Scene 이름에 맞게 변경
        {
            GameObject invBaseObject = GameObject.Find("InvBase");
            if (invBaseObject != null)
            {
                baseSlotParent = invBaseObject.transform;
                Debug.Log("InvBase와 baseSlotParent가 연결되었습니다.");

                // baseSlots 초기화
                baseSlots = baseSlotParent.GetComponentsInChildren<ItemSlot>();
                Debug.Log($"baseSlots 초기화 완료: {baseSlots.Length}개 슬롯이 설정되었습니다.");

                // 슬롯 갱신
                FreshSlot();
            }
            else
            {
                Debug.LogWarning("InvBase를 찾을 수 없습니다. BattleUIScene에 InvBase가 있는지 확인하세요.");
            }
        }
    }
*/
  /*  public void FreshSlot()
    {
        if (baseSlots == null || baseSlotParent == null)
        {
            Debug.LogWarning("Base Slots 또는 Base Slot Parent가 설정되지 않았습니다.");
            return;
        }

        // Base Inventory 갱신
        int i = 0;
        for (; i < relics.Count && i < baseSlots.Length; i++)
        {
            baseSlots[i].SetRelic(relics[i]); // 슬롯에 유물 데이터 설정
        }
    }
*/
    public void AddRelicToInventory(string relicName)
    {
        // RelicManager에서 유물 데이터 검색
        Debug.Log($"RelicManager COUNT : {RelicManager.Instance.activeRelics.Count}");
        if (RelicManager.Instance.allRelics.ContainsKey(relicName))
        {
            Relic relic = RelicManager.Instance.allRelics[relicName];
            if (relic != null && !relics.Contains(relic)) // 중복 방지
        {
            relics.Add(relic);
            RelicManager.Instance.AddRelic(relicName);
            Debug.Log($"[AddRelicToInventory] Relic added: {relic.Name}");
            Debug.Log($"Description: {relic.Description}");
            Debug.Log($"Sprite: {(relic.Image != null ? relic.Image.name : "No Image Found")}");

            //FreshSlot(); // UI 갱신
        }

        else
        {
            Debug.LogWarning($"[AddRelicToInventory] Failed to add relic: {relicName}");
            Debug.Log($"Reason: {(relic == null ? "Relic not found in RelicManager" : "Relic already in inventory")}");
        }
        }

    }
}
