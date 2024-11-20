using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    public static RelicManager Instance;

    private List<Relic> activeRelics = new List<Relic>();
    private Dictionary<string, Relic> allRelics = new Dictionary<string, Relic>();

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
        // 유물 등록 예제
        allRelics.Add("Cost Relic", new Relic(
            "Cost Relic",
            "Increases cost regeneration speed when cost is 3 or higher.",
            condition => condition.CurrentCost >= 3, // 조건
            condition =>
            {
                Debug.Log("Cost Relic Effect Activated: Cost regeneration speed increased!");
                // 실제 효과 로직
            }
        ));

        allRelics.Add("Health Relic", new Relic(
            "Health Relic",                                                 //이름
            "Heals the player if health drops below 50.",                   / 설명
            condition => condition.PlayerHealth < 50,                       // 조건
            condition =>                                                    // 효과
            {
                Debug.Log("Health Relic Effect Activated: Player healed!");
                condition.PlayerHealth += 10; // 효과 예제
            }
        ));

        // 추가 유물 등록 가능
        */
    }
}
