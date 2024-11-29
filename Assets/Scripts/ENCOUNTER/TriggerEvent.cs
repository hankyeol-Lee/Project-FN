using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public static TriggerEvent Instance;
    public EncounterManager encounterManager; // EncounterManager ����
    public int randomIndex;

    public EncounterData[] encounterPool; // ��� ScriptableObject �����͸� ����
    private void Awake()
    {
        // �̱��� ����
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
        // Resources �������� EncounterData �ε�
        encounterPool = Resources.LoadAll<EncounterData>("EncounterData");
    }

    public void OnEventTriggered()
    {
        if (encounterManager == null)
        {
            Debug.LogError("EncounterManager�� TriggerEvent�� ������� �ʾҽ��ϴ�!");
            return;
        }
        // �������� �ϳ� ����
        randomIndex = Random.Range(0, encounterPool.Length);
        EncounterData randomEncounter = encounterPool[randomIndex];
        encounterManager.TriggerEncounter(randomEncounter);
        Debug.Log($"Encounter {randomIndex} Selected");
    }
}
