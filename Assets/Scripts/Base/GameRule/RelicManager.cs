using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    public static RelicManager Instance;

    public List<Relic> activeRelics = new List<Relic>();
    public Dictionary<string, Relic> allRelics = new Dictionary<string, Relic>();
    public Dictionary<string, int> activeRelicsDict = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        RegisterRelics();
    }

    public void AddRelic(string relicName) // ���� �߰����ִ� �޼ҵ�~ ����ε� �̸��� �����ּ���~
    {
        if (allRelics.TryGetValue(relicName, out var relic) && !activeRelics.Contains(relic))
        {
            activeRelics.Add(relic);
            activeRelicsDict.Add(relicName, 1);
            // UI�� ���� �߰���Ű�� �ڵ� �ڸ�
        }
    }

    public void RemoveRelic(string relicName)
    {
        var relic = activeRelics.Find(r => r.Name == relicName);
        if (relic != null)
        {
            activeRelics.Remove(relic);
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
        // Old Helmet
        allRelics.Add("Old Helmet", new Relic(
            "Old Helmet",
            "ü�� +10",
            condition => activeRelicsDict["Old Helmet"] == 1,
            condition =>
            {
                condition.P_Health += 10;
                activeRelicsDict["Old Helmet"] = 0; // ȿ�� ���� �� ��Ȱ��ȭ
                Debug.Log("����ѽ�!!");
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Old Sword
        allRelics.Add("Old Sword", new Relic(
            "Old Sword",
            "���� ���ݷ� + 1",
            condition => activeRelicsDict["Old Sword"] == 1,
            condition =>
            {
                condition.P_AD += 1;
                activeRelicsDict["Old Sword"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Old Orb
        allRelics.Add("Old Orb", new Relic(
            "Old Orb",
            "���� ���ݷ� +1",
            condition => activeRelicsDict["Old Orb"] == 1,
            condition =>
            {
                condition.P_AP += 1;
                activeRelicsDict["Old Orb"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Old Armor
        allRelics.Add("Old Armor", new Relic(
            "Old Armor",
            "���� ���� +1",
            condition => activeRelicsDict["Old Armor"] == 1,
            condition =>
            {
                condition.P_AR += 1;
                activeRelicsDict["Old Armor"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Old Bead
        allRelics.Add("Old Bead", new Relic(
            "Old Bead",
            "���� ���� +1",
            condition => activeRelicsDict["Old Bead"] == 1,
            condition =>
            {
                condition.P_MR += 1;
                activeRelicsDict["Old Bead"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ordinary Helmet
        allRelics.Add("Ordinary Helmet", new Relic(
            "Ordinary Helmet",
            "ü�� +20",
            condition => activeRelicsDict["Ordinary Helmet"] == 1,
            condition =>
            {
                condition.P_Health += 20;
                activeRelicsDict["Ordinary Helmet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ordinary Sword
        allRelics.Add("Ordinary Sword", new Relic(
            "Ordinary Sword",
            "���� ���ݷ� + 2",
            condition => activeRelicsDict["Ordinary Sword"] == 1,
            condition =>
            {
                condition.P_AD += 2;
                activeRelicsDict["Ordinary Sword"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ordinary Orb
        allRelics.Add("Ordinary Orb", new Relic(
            "Ordinary Orb",
            "���� ���ݷ� +2",
            condition => activeRelicsDict["Ordinary Orb"] == 1,
            condition =>
            {
                condition.P_AP += 2;
                activeRelicsDict["Ordinary Orb"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ordinary Armor
        allRelics.Add("Ordinary Armor", new Relic(
            "Ordinary Armor",
            "���� ���� +2",
            condition => activeRelicsDict["Ordinary Armor"] == 1,
            condition =>
            {
                condition.P_AR += 2;
                activeRelicsDict["Ordinary Armor"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ordinary Amulet
        allRelics.Add("Ordinary Amulet", new Relic(
            "Ordinary Amulet",
            "���� ���� +2",
            condition => activeRelicsDict["Ordinary Amulet"] == 1,
            condition =>
            {
                condition.P_MR += 2;
                activeRelicsDict["Ordinary Amulet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ordinary Boots
        allRelics.Add("Ordinary Boots", new Relic(
            "Ordinary Boots",
            "���� ����, ���� ���� +1",
            condition => activeRelicsDict["Ordinary Boots"] == 1,
            condition =>
            {
                condition.P_AR += 1;
                condition.P_MR += 1;
                activeRelicsDict["Ordinary Boots"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Helmet
        allRelics.Add("Unusual Helmet", new Relic(
            "Unusual Helmet",
            "ü�� +30",
            condition => activeRelicsDict["Unusual Helmet"] == 1,
            condition =>
            {
                condition.P_Health += 30;
                activeRelicsDict["Unusual Helmet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Sword
        allRelics.Add("Unusual Sword", new Relic(
            "Unusual Sword",
            "���� ���ݷ� + 3",
            condition => activeRelicsDict["Unusual Sword"] == 1,
            condition =>
            {
                condition.P_AD += 3;
                activeRelicsDict["Unusual Sword"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Orb
        allRelics.Add("Unusual Orb", new Relic(
            "Unusual Orb",
            "���� ���ݷ� +3",
            condition => activeRelicsDict["Unusual Orb"] == 1,
            condition =>
            {
                condition.P_AP += 3;
                activeRelicsDict["Unusual Orb"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Armor
        allRelics.Add("Unusual Armor", new Relic(
            "Unusual Armor",
            "���� ���� +3",
            condition => activeRelicsDict["Unusual Armor"] == 1,
            condition =>
            {
                condition.P_AR += 3;
                activeRelicsDict["Unusual Armor"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Amulet
        allRelics.Add("Unusual Amulet", new Relic(
            "Unusual Amulet",
            "���� ���� +3",
            condition => activeRelicsDict["Unusual Amulet"] == 1,
            condition =>
            {
                condition.P_MR += 3;
                activeRelicsDict["Unusual Amulet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Boots
        allRelics.Add("Unusual Boots", new Relic(
            "Unusual Boots",
            "���� ���� +2, ���� ���� +2",
            condition => activeRelicsDict["Unusual Boots"] == 1,
            condition =>
            {
                condition.P_MR += 2;
                condition.P_AR += 2;
                activeRelicsDict["Unusual Boots"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Unusual Device
        allRelics.Add("Unusual Device", new Relic(
            "Unusual Device",
            "�ڽ�Ʈ ȸ���� +10%",
            condition => activeRelicsDict["Unusual Device"] == 1,
            condition =>
            {
                condition.Cost_Fill += condition.Cost_Fill * 0.1f;
                activeRelicsDict["Unusual Device"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Helmet
        allRelics.Add("Hero's Helmet", new Relic(
            "Hero's Helmet",
            "ü�� +50",
            condition => activeRelicsDict["Hero's Helmet"] == 1,
            condition =>
            {
                condition.P_Health += 50;
                activeRelicsDict["Hero's Helmet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Sword
        allRelics.Add("Hero's Sword", new Relic(
            "Hero's Sword",
            "���� ���ݷ� +5",
            condition => activeRelicsDict["Hero's Sword"] == 1,
            condition =>
            {
                condition.P_AD += 5;
                activeRelicsDict["Hero's Sword"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Orb
        allRelics.Add("Hero's Orb", new Relic(
            "Hero's Orb",
            "���� ���ݷ� +5",
            condition => activeRelicsDict["Hero's Orb"] == 1,
            condition =>
            {
                condition.P_AP += 5;
                activeRelicsDict["Hero's Orb"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Armor
        allRelics.Add("Hero's Armor", new Relic(
            "Hero's Armor",
            "���� ���� +5",
            condition => activeRelicsDict["Hero's Armor"] == 1,
            condition =>
            {
                condition.P_AR += 5;
                activeRelicsDict["Hero's Armor"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Amulet
        allRelics.Add("Hero's Amulet", new Relic(
            "Hero's Amulet",
            "���� ���� +5",
            condition => activeRelicsDict["Hero's Amulet"] == 1,
            condition =>
            {
                condition.P_MR += 5;
                activeRelicsDict["Hero's Amulet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Boots
        allRelics.Add("Hero's Boots", new Relic(
            "Hero's Boots",
            "���� ���� +3, ���� ���� +3",
            condition => activeRelicsDict["Hero's Boots"] == 1,
            condition =>
            {
                condition.P_AR += 3;
                condition.P_MR += 3;
                activeRelicsDict["Hero's Boots"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Hero's Device
        allRelics.Add("Hero's Device", new Relic(
            "Hero's Device",
            "�ڽ�Ʈ ȸ���� +20%",
            condition => activeRelicsDict["Hero's Device"] == 1,
            condition =>
            {
                condition.Cost_Fill += condition.Cost_Fill * 0.2f;
                activeRelicsDict["Hero's Device"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));


        // Calm Mind
        allRelics.Add("Calm Mind", new Relic(
            "Calm Mind",
            "�ڽ�Ʈ ȸ���� +30%",
            condition => activeRelicsDict["Calm Mind"] == 1,
            condition =>
            {
                condition.Cost_Fill += condition.Cost_Fill * 0.3f;
                activeRelicsDict["Calm Mind"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Helmet
        allRelics.Add("Cursed Helmet", new Relic(
            "Cursed Helmet",
            "ü�� +50, ���� ���� -2",
            condition => activeRelicsDict["Cursed Helmet"] == 1,
            condition =>
            {
                condition.P_Health += 50;
                condition.P_AR -= 2;
                activeRelicsDict["Cursed Helmet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Sword
        allRelics.Add("Cursed Sword", new Relic(
            "Cursed Sword",
            "���� ���ݷ� +5, ���� ���ݷ� -2",
            condition => activeRelicsDict["Cursed Sword"] == 1,
            condition =>
            {
                condition.P_AD += 5;
                condition.P_AP -= 2;
                activeRelicsDict["Cursed Sword"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Orb
        allRelics.Add("Cursed Orb", new Relic(
            "Cursed Orb",
            "���� ���ݷ� +5, ���� ���ݷ� -2",
            condition => activeRelicsDict["Cursed Orb"] == 1,
            condition =>
            {
                condition.P_AP += 5;
                condition.P_AD -= 2;
                activeRelicsDict["Cursed Orb"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Armor
        allRelics.Add("Cursed Armor", new Relic(
            "Cursed Armor",
            "���� ���� +5, ���� ���� -2",
            condition => activeRelicsDict["Cursed Armor"] == 1,
            condition =>
            {
                condition.P_AR += 5;
                condition.P_MR -= 2;
                activeRelicsDict["Cursed Armor"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Amulet
        allRelics.Add("Cursed Amulet", new Relic(
            "Cursed Amulet",
            "���� ���� +5, ���� ���� -2",
            condition => activeRelicsDict["Cursed Amulet"] == 1,
            condition =>
            {
                condition.P_MR += 5;
                condition.P_AR -= 2;
                activeRelicsDict["Cursed Amulet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Boots
        allRelics.Add("Cursed Boots", new Relic(
            "Cursed Boots",
            "���� ���� +2, ü�� -20",
            condition => activeRelicsDict["Cursed Boots"] == 1,
            condition =>
            {
                condition.P_AR += 2;
                condition.P_Health -= 20;
                activeRelicsDict["Cursed Boots"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Cursed Device
        allRelics.Add("Cursed Device", new Relic(
            "Cursed Device",
            "�ڽ�Ʈ ȸ���� +20%, ü�� -20",
            condition => activeRelicsDict["Cursed Device"] == 1,
            condition =>
            {
                condition.Cost_Fill += condition.Cost_Fill * 0.2f;
                condition.P_Health -= 20;
                activeRelicsDict["Cursed Device"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Rash Mind
        allRelics.Add("Rash Mind", new Relic(
            "Rash Mind",
            "�ڽ�Ʈ ȸ���� -10%, ü�� +20",
            condition => activeRelicsDict["Rash Mind"] == 1,
            condition =>
            {
                condition.Cost_Fill -= condition.Cost_Fill * 0.1f;
                condition.P_Health += 20;
                activeRelicsDict["Rash Mind"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Fully Charged Battery
        allRelics.Add("Fully Charged Battery", new Relic(
            "Fully Charged Battery",
            "�ڽ�Ʈ�� 9 �̻��̸� ��� �ɷ�ġ +2",
            condition => activeRelicsDict["Fully Charged Battery"] == 1 && condition.Cur_Cost >= 9,
            condition =>
            {
                condition.P_Health += 2;
                condition.P_AD += 2;
                condition.P_AP += 2;
                condition.P_AR += 2;
                condition.P_MR += 2;
                activeRelicsDict["Fully Charged Battery"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Emergency Charge
        allRelics.Add("Emergency Charge", new Relic(
            "Emergency Charge",
            "���� �� ������ 5 �߰�",
            condition => activeRelicsDict["Emergency Charge"] == 1,
            condition =>
            {
                condition.Cur_Cost += 5;
                UI_EnergyBar.Instance.currentHealth += 5;
                activeRelicsDict["Emergency Charge"] = 0;
                UI_EnergyBar.Instance.UpdateHealthBar();
                UI_EnergyBar.Instance.UpdateHealthText();
                
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Gold Medal
        allRelics.Add("Gold Medal", new Relic(
            "Gold Medal",
            "��ü �ɷ�ġ +5",
            condition => activeRelicsDict["Gold Medal"] == 1,
            condition =>
            {
                condition.P_Health += 5;
                condition.P_AD += 5;
                condition.P_AP += 5;
                condition.P_AR += 5;
                condition.P_MR += 5;
                activeRelicsDict["Gold Medal"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Silver Medal
        allRelics.Add("Silver Medal", new Relic(
            "Silver Medal",
            "��ü �ɷ�ġ +3",
            condition => activeRelicsDict["Silver Medal"] == 1,
            condition =>
            {
                condition.P_Health += 3;
                condition.P_AD += 3;
                condition.P_AP += 3;
                condition.P_AR += 3;
                condition.P_MR += 3;
                activeRelicsDict["Silver Medal"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Bronze Medal
        allRelics.Add("Bronze Medal", new Relic(
            "Bronze Medal",
            "��ü �ɷ�ġ +2",
            condition => activeRelicsDict["Bronze Medal"] == 1,
            condition =>
            {
                condition.P_Health += 2;
                condition.P_AD += 2;
                condition.P_AP += 2;
                condition.P_AR += 2;
                condition.P_MR += 2;
                activeRelicsDict["Bronze Medal"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Heavy Helmet
        allRelics.Add("Heavy Helmet", new Relic(
            "Heavy Helmet",
            "ü�� +30",
            condition => activeRelicsDict["Heavy Helmet"] == 1,
            condition =>
            {
                condition.P_Health += 30;
                activeRelicsDict["Heavy Helmet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Heavy Sword
        allRelics.Add("Heavy Sword", new Relic(
            "Heavy Sword",
            "���� ���ݷ� +3",
            condition => activeRelicsDict["Heavy Sword"] == 1,
            condition =>
            {
                condition.P_AD += 3;
                activeRelicsDict["Heavy Sword"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Heavy Orb
        allRelics.Add("Heavy Orb", new Relic(
            "Heavy Orb",
            "���� ���ݷ� +3",
            condition => activeRelicsDict["Heavy Orb"] == 1,
            condition =>
            {
                condition.P_AP += 3;
                activeRelicsDict["Heavy Orb"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Heavy Armor
        allRelics.Add("Heavy Armor", new Relic(
            "Heavy Armor",
            "���� ���� +3",
            condition => activeRelicsDict["Heavy Armor"] == 1,
            condition =>
            {
                condition.P_AR += 3;
                activeRelicsDict["Heavy Armor"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Heavy Amulet
        allRelics.Add("Heavy Amulet", new Relic(
            "Heavy Amulet",
            "���� ���� +3",
            condition => activeRelicsDict["Heavy Amulet"] == 1,
            condition =>
            {
                condition.P_MR += 3;
                activeRelicsDict["Heavy Amulet"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Heavy Boots
        allRelics.Add("Heavy Boots", new Relic(
            "Heavy Boots",
            "���� ���� +2, ���� ���� +2",
            condition => activeRelicsDict["Heavy Boots"] == 1,
            condition =>
            {
                condition.P_AR += 2;
                condition.P_MR += 2;
                activeRelicsDict["Heavy Boots"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Solid and Heavy
        allRelics.Add("Solid and Heavy", new Relic(
            "Solid and Heavy",
            "ü�� +10, ������ �ɷ�ġ 1 ����",
            condition => activeRelicsDict["Solid and Heavy"] == 1,
            condition =>
            {
                condition.P_Health += 10;
                int randomStat = UnityEngine.Random.Range(0, 4); // 0: P_AD, 1: P_AP, 2: P_AR, 3: P_MR
                switch (randomStat)
                {
                    case 0: condition.P_AD += 1; break;
                    case 1: condition.P_AP += 1; break;
                    case 2: condition.P_AR += 1; break;
                    case 3: condition.P_MR += 1; break;
                }
                activeRelicsDict["Solid and Heavy"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Suspicious Cube
        allRelics.Add("Suspicious Cube", new Relic(
            "Suspicious Cube",
            "���� ���� �ɷ�ġ �� ���� +1, ���� �� -1",
            condition => activeRelicsDict["Suspicious Cube"] == 1,
            condition =>
            {
                var stats = new List<(string, float)>()
                {
            ("P_Health", condition.P_Health),
            ("P_AD", condition.P_AD),
            ("P_AP", condition.P_AP),
            ("P_AR", condition.P_AR),
            ("P_MR", condition.P_MR)
                };

                stats = stats.OrderByDescending(stat => stat.Item2).ToList();
                condition.GetType().GetField(stats[0].Item1).SetValue(condition, (float)stats[0].Item2 + 1);
                condition.GetType().GetField(stats[1].Item1).SetValue(condition, (float)stats[1].Item2 + 1);
                condition.GetType().GetField(stats.Last().Item1).SetValue(condition, (float)stats.Last().Item2 - 1);
                activeRelicsDict["Suspicious Cube"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Red Cube
        allRelics.Add("Red Cube", new Relic(
            "Red Cube",
            "���� ���� �ɷ�ġ �� ���� +2, ���� �� -2",
            condition => activeRelicsDict["Red Cube"] == 1,
            condition =>
            {
                var stats = new List<(string, float)>()
                {
            ("P_Health", condition.P_Health),
            ("P_AD", condition.P_AD),
            ("P_AP", condition.P_AP),
            ("P_AR", condition.P_AR),
            ("P_MR", condition.P_MR)
                };

                stats = stats.OrderByDescending(stat => stat.Item2).ToList();
                condition.GetType().GetField(stats[0].Item1).SetValue(condition, (float)stats[0].Item2 + 2);
                condition.GetType().GetField(stats[1].Item1).SetValue(condition, (float)stats[1].Item2 + 2);
                condition.GetType().GetField(stats.Last().Item1).SetValue(condition, (float)stats.Last().Item2 - 2);
                activeRelicsDict["Red Cube"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Black Cube
        allRelics.Add("Black Cube", new Relic(
            "Black Cube",
            "���� ���� �ɷ�ġ �� ���� +3, ���� �� -3",
            condition => activeRelicsDict["Black Cube"] == 1,
            condition =>
            {
                var stats = new List<(string, float)>()
                {
            ("P_Health", condition.P_Health),
            ("P_AD", condition.P_AD),
            ("P_AP", condition.P_AP),
            ("P_AR", condition.P_AR),
            ("P_MR", condition.P_MR)
                };

                stats = stats.OrderByDescending(stat => stat.Item2).ToList();
                condition.GetType().GetField(stats[0].Item1).SetValue(condition, (float)stats[0].Item2 + 3);
                condition.GetType().GetField(stats[1].Item1).SetValue(condition, (float)stats[1].Item2 + 3);
                condition.GetType().GetField(stats.Last().Item1).SetValue(condition, (float)stats.Last().Item2 - 3);
                activeRelicsDict["Black Cube"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Amazing Cube
        allRelics.Add("Amazing Cube", new Relic(
            "Amazing Cube",
            "���� ���� �ɷ�ġ �� ���� +5, ���� �� -5",
            condition => activeRelicsDict["Amazing Cube"] == 1,
            condition =>
            {
                var stats = new List<(string, float)>()
                {
            ("P_Health", condition.P_Health),
            ("P_AD", condition.P_AD),
            ("P_AP", condition.P_AP),
            ("P_AR", condition.P_AR),
            ("P_MR", condition.P_MR)
                };

                stats = stats.OrderByDescending(stat => stat.Item2).ToList();
                for (int i = 0; i < 3; i++)
                    condition.GetType().GetField(stats[i].Item1).SetValue(condition, (float)stats[i].Item2 + 5);
                condition.GetType().GetField(stats.Last().Item1).SetValue(condition, (float)stats.Last().Item2 - 5);
                activeRelicsDict["Amazing Cube"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Diamond
        allRelics.Add("Diamond", new Relic(
            "Diamond",
            "ü���� 150���� ����",
            condition => activeRelicsDict["Diamond"] == 1,
            condition =>
            {
                condition.P_Health = 150;
                activeRelicsDict["Diamond"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Ruby
        allRelics.Add("Ruby", new Relic(
            "Ruby",
            "���� ���ݷ��� 15�� ����",
            condition => activeRelicsDict["Ruby"] == 1,
            condition =>
            {
                condition.P_AD = 15;
                activeRelicsDict["Ruby"] = 0;
            },
            "Ruby" // RelicImages �������� �̹��� �ε�
        ));

        // Emerald
        allRelics.Add("Emerald", new Relic(
            "Emerald",
            "���� ���ݷ��� 15�� ����",
            condition => activeRelicsDict["Emerald"] == 1,
            condition =>
            {
                condition.P_AP = 15;
                activeRelicsDict["Emerald"] = 0;
            },
            "Emerald" // RelicImages �������� �̹��� �ε�
        ));

        // Sapphire
        allRelics.Add("Sapphire", new Relic(
            "Sapphire",
            "���� ������ 15�� ����",
            condition => activeRelicsDict["Sapphire"] == 1,
            condition =>
            {
                condition.P_AR = 15;
                activeRelicsDict["Sapphire"] = 0;
            },
            "Sapphire" // RelicImages �������� �̹��� �ε�
        ));

        // Garnet
        allRelics.Add("Garnet", new Relic(
            "Garnet",
            "���� ������ 15�� ����",
            condition => activeRelicsDict["Garnet"] == 1,
            condition =>
            {
                condition.P_MR = 15;
                activeRelicsDict["Garnet"] = 0;
            },
            "Garnet" // RelicImages �������� �̹��� �ε�
        ));

        // Amber
        allRelics.Add("Amber", new Relic(
            "Amber",
            "��ü �ɷ�ġ +5",
            condition => activeRelicsDict["Amber"] == 1,
            condition =>
            {
                condition.P_Health += 5;
                condition.P_AD += 5;
                condition.P_AP += 5;
                condition.P_AR += 5;
                condition.P_MR += 5;
                activeRelicsDict["Amber"] = 0;
            },
            "Amber" // RelicImages �������� �̹��� �ε�
        ));

        // Ultra Recovery
        allRelics.Add("Ultra Recovery", new Relic(
            "Ultra Recovery",
            "ü�� +50",
            condition => activeRelicsDict["Ultra Recovery"] == 1,
            condition =>
            {
                condition.P_Health += 50;
                activeRelicsDict["Ultra Recovery"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));

        // Strange Gem
        allRelics.Add("Strange Gem", new Relic(
            "Strange Gem",
            "��� �ɷ�ġ�� 15��, ü���� 150����",
            condition => activeRelicsDict["Strange Gem"] == 1,
            condition =>
            {
                condition.P_Health = 150;
                condition.P_AD = 15;
                condition.P_AP = 15;
                condition.P_AR = 15;
                condition.P_MR = 15;
                activeRelicsDict["Strange Gem"] = 0;
            },
            "Diamond" // RelicImages �������� �̹��� �ε�
        ));
    }
}
