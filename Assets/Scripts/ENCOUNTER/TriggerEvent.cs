using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public static TriggerEvent Instance;
    public EncounterManager encounterManager; // EncounterManager 연결
    public int randomIndex;

    public EncounterData[] encounterPool; // 모든 ScriptableObject 데이터를 저장
    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Resources 폴더에서 EncounterData 로드
        encounterPool = Resources.LoadAll<EncounterData>("EncounterData");
    }

    public void OnEventTriggered()
    {
        if (encounterManager == null)
        {
            Debug.LogError("EncounterManager가 TriggerEvent에 연결되지 않았습니다!");
            return;
        }
        // 랜덤으로 하나 선택
        randomIndex = Random.Range(0, encounterPool.Length);
        EncounterData randomEncounter = encounterPool[randomIndex];
        encounterManager.TriggerEncounter(randomEncounter);
        Debug.Log($"Encounter {randomIndex} Selected");
    }
}
