using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    public static RelicManager Instance;

    public List<Relic> activeRelics = new List<Relic>();
    private Dictionary<string, Relic> allRelics = new Dictionary<string, Relic>();
    public Dictionary<string, int> activeRelicsDIct = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        RegisterRelics();
    }

    public void AddRelic(string relicName)
    {
        if (allRelics.TryGetValue(relicName, out var relic) && !activeRelics.Contains(relic))
        {
            activeRelics.Add(relic);
            Debug.Log($"{relicName} added.");
        }
    }

    public void RemoveRelic(string relicName)
    {
        var relic = activeRelics.Find(r => r.Name == relicName);
        if (relic != null)
        {
            activeRelics.Remove(relic);
            Debug.Log($"{relicName} removed.");
        }
    }

    public void CheckRelics(GameCondition condition)
    {
        foreach (var relic in activeRelics)
        {
            relic.CheckAndApply(condition);
        }
    }

    private void RegisterRelics()
    {
        /*
        // ���� ��� ����
        allRelics.Add("Cost Relic", new Relic(
            "Cost Relic",
            "Increases cost regeneration speed when cost is 3 or higher.",
            condition => condition.CurrentCost >= 3, // ����
            condition =>
            {
                Debug.Log("Cost Relic Effect Activated: Cost regeneration speed increased!");
                // ���� ȿ�� ����
            }
        ));


        allRelics.Add("Health Relic", new Relic(
            "Health Relic",                                                 //�̸�
            "Heals the player if health drops below 50.",                   / ����
            condition => condition.PlayerHealth < 50,                       // ����
            condition =>                                                    // ȿ��
            {
                Debug.Log("Health Relic Effect Activated: Player healed!");
                condition.PlayerHealth += 10; // ȿ�� ����
            }
        ));

        // �߰� ���� ��� ����
        */
        allRelics.Add("Old Helmet", new Relic(
            "Old Helmet",
            "ü�� +10",
            condition => true, // ����
            condition =>
            {
                condition.P_Health += 10;  //ȿ��
            }
        ));
    }
}
