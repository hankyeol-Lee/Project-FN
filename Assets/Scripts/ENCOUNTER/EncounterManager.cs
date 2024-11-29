using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    public GameObject encounterUIPrefab; // UI �˾� ������
    public Canvas canvas; // �˾��� ��� ĵ����
    private GameObject currentUI; // ���� Ȱ��ȭ�� UI
    private static EncounterManager Instance;


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
    public void TriggerEncounter(EncounterData encounter)
    {
        // �˾� ����
        currentUI = Instantiate(encounterUIPrefab, canvas.transform);

        // �˾� ����
        TMP_Text encounterNameText = currentUI.transform.Find("EncounterNameText").GetComponent<TMP_Text>();
        TMP_Text encounterDescriptionText = currentUI.transform.Find("EncounterDescriptionText").GetComponent<TMP_Text>();
        Transform buttonGroup = currentUI.transform.Find("Buttons");

        // ������ ����
        encounterNameText.text = encounter.encounterName;
        encounterDescriptionText.text = encounter.encounterDescription;
        int Index = TriggerEvent.Instance.randomIndex;

        // ��ư �ʱ�ȭ
        foreach (Transform child in buttonGroup)
            Destroy(child.gameObject); // ���� ��ư ����

        for (int i = 0; i < encounter.choices.Count; i++)
        {
            string choiceText = encounter.choices[i];
            int capturedIndex = i; // ĸó�� �ε���

            // ��ư ���� �� ����
            GameObject buttonObject = new GameObject("Button", typeof(RectTransform), typeof(Button), typeof(Text));
            buttonObject.transform.SetParent(buttonGroup);

            RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1000, 50); // ��ư ũ��

            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => HandleChoice(Index, capturedIndex)); // ĸó�� �ε����� ����

            Text buttonText = buttonObject.GetComponent<Text>();
            buttonText.text = choiceText;
            buttonText.font = Resources.Load("HeirofLightRegular") as Font;
            buttonText.fontSize = 35;
            buttonText.alignment = TextAnchor.MiddleCenter;
            buttonText.color = Color.white;
        }

        // �ݱ� ��ư ����
    }

    public void HandleChoice(int encounterIndex, int choiceIndex)
    {
        
        switch (encounterIndex)
        {
            case 0: // EncounterPool[0]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Old Helmet", "Old Sword", "Old Orb", "Old Armor", "Old Bead" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    ToastMessage.Instance.message = $"{selectedRelic} ȹ��";
                }
                break;
                    case 1: // EncounterPool[1]
            switch (choiceIndex)
            {
                case 0: // 1�� ������
                    PlayerStatus.Instance.playerHP -= 50;
                    PlayerStatus.Instance.playerAR += 10;
                    PlayerStatus.Instance.playerMR += 10;
                    Debug.Log("1�� ������: HP -50, AR +10, MR +10");
                    break;
                case 1: // 2�� ������
                    int randomStat1 = Random.Range(0, 5);
                    ApplyRandomStatIncrease(randomStat1, 15);
                    Debug.Log($"2�� ������: ���� ���� +15");
                    break;
                case 2: // 3�� ������
                    PlayerStatus.Instance.playerHP -= 50;
                    PlayerStatus.Instance.playerAD += 15;
                    Debug.Log("3�� ������: HP -50, AD +15");
                    break;
                case 3: // 4�� ������
                    PlayerStatus.Instance.playerAD += 15;
                    PlayerStatus.Instance.playerAP += 15;
                    PlayerStatus.Instance.playerAR -= 10;
                    PlayerStatus.Instance.playerMR -= 10;
                    Debug.Log("4�� ������: AD +15, AP +15, AR -10, MR -10");
                    break;
                case 4: // 5�� ������
                    PlayerStatus.Instance.playerHP -= 50;
                    PlayerStatus.Instance.playerAP += 15;
                    Debug.Log("5�� ������: HP -50, AP +15");
                    break;
                case 5: // 6�� ������
                    PlayerStatus.Instance.playerHP += 200;
                    PlayerStatus.Instance.playerAR -= 10;
                    PlayerStatus.Instance.playerMR -= 10;
                    Debug.Log("6�� ������: HP +200, AR -10, MR -10");
                    break;
                case 6: // 7�� ������
                    PlayerStatus.Instance.playerHP += 200;
                    PlayerStatus.Instance.costResilience = 100;
                    Debug.Log("7�� ������: HP +200, costResilience = 100");
                    break;
            }
            break;

        case 2: // EncounterPool[2]
            switch (choiceIndex)
            {
                case 0: // 1�� ������
                    PlayerStatus.Instance.playerHP += 100;
                    Debug.Log("1�� ������: HP +100");
                    break;
                case 1: // 2�� ������
                    int randomStat2 = Random.Range(0, 5);
                    ApplyRandomStatIncrease(randomStat2, 15);
                    Debug.Log($"2�� ������: ���� ���� +15");
                    break;
                case 2: // 3�� ������
                    PlayerStatus.Instance.playerHP += 150;
                    PlayerStatus.Instance.playerAD -= 5;
                    Debug.Log("3�� ������: HP +150, AD -5");
                    break;
                case 3: // 4�� ������
                    PlayerStatus.Instance.playerAD -= 5;
                    PlayerStatus.Instance.playerAP -= 5;
                    PlayerStatus.Instance.playerAR += 10;
                    PlayerStatus.Instance.playerMR += 10;
                    Debug.Log("4�� ������: AD -5, AP -5, AR +10, MR +10");
                    break;
                case 4:
                    PlayerStatus.Instance.playerHP += 150;
                    PlayerStatus.Instance.playerAP -= 5;
                    Debug.Log("5�� ������: HP +150, AP -5");
                    break;
                case 5: // 5�� ������
                    PlayerStatus.Instance.playerAR += 5;
                    PlayerStatus.Instance.playerMR += 5;
                    Debug.Log("6�� ������: AR +5, MR +5");
                    break;
                case 6: // 6�� ������
                    PlayerStatus.Instance.costResilience = 300;
                    Debug.Log("7�� ������: costResilience = 200");
                    break;
            }
            break;

            case 3: // EncounterPool[3]
                if (choiceIndex == 0)
                {
                    float randomChance = Random.value; // 0.0 ~ 1.0 ������ ���� ��
                    if (randomChance <= 0.5f) // 50% Ȯ��
                    {
                        string[] relics = { "Ordinary Helmet", "Ordinary Sword", "Ordinary Orb", "Ordinary Armor", "Ordinary Amulet", "Ordinary Boots" };
                        string selectedRelic = relics[Random.Range(0, relics.Length)];
                        InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                        ToastMessage.Instance.message = $"{selectedRelic} ȹ��";
                    }
                    else // ������ 50% Ȯ��
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        ToastMessage.Instance.message = "HP -20";
                    }
                }
                else if (choiceIndex == 1)
                {
                    // �ƹ� ���� ����
                }
                break;

            case 4: // EncounterPool[4]
                if (choiceIndex == 0)
                {
                    ToastMessage.Instance.message = "���̾��׿�.";
                }
                else if (choiceIndex == 1)
                {
                    ToastMessage.Instance.message = "�����ƽ��ϴ�. �׳� ���̾��׿�.";
                }
                break;

            case 5: // EncounterPool[5]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Diamond", "Ruby", "Emerald", "Sapphire", "Garnet", "Amber" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    ToastMessage.Instance.message = $"{selectedRelic} ȹ��";
                }
                else if (choiceIndex == 1)
                {
                    ToastMessage.Instance.message = "�����ƽ��ϴ�.";
                }
                break;

            case 6: // EncounterPool[6]
                if (choiceIndex == 0)
                {
                    string[] medals = { "Gold Medal", "Silver Medal", "Bronze Medal" };
                    string selectedMedal = medals[Random.Range(0, medals.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedMedal);
                    ToastMessage.Instance.message = $"{selectedMedal} ȹ��";
                }
                break;

            case 7: // EncounterPool[7]
                if (choiceIndex == 0)
                {
                    InventoryManager.Instance.AddRelicToInventory("Hero's Helmet");
                    ToastMessage.Instance.message = "Hero's Helmet ȹ��";
                }
                else if (choiceIndex == 1)
                {
                    Debug.Log("passed");
                }
                break;

            case 8: // EncounterPool[8]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Hero's Helmet", "Hero's Sword", "Hero's Orb", "Hero's Armor", "Hero's Amulet", "Hero's Boots", "Hero's Device" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    ToastMessage.Instance.message = $"{selectedRelic} ȹ��";
                }
                break;

            case 9: // EncounterPool[9]
                if (choiceIndex == 0)
                {
                    if (PlayerStatus.Instance.playerAD >= 30)
                    {
                        ToastMessage.Instance.message = "������ Ż���ߴ�.";
                    }
                    else
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        ToastMessage.Instance.message = "�������̾���. ������ �������Դ�. HP -20";
                    }
                }
                else if (choiceIndex == 1)
                {
                    if (PlayerStatus.Instance.playerAP >= 30)
                    {
                        ToastMessage.Instance.message = "������ Ż���ߴ�.";
                    }
                    else
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        ToastMessage.Instance.message = "�������̾���. ������ �������Դ�. HP -20";
                    }
                }
                else if (choiceIndex == 2)
                {
                    PlayerStatus.Instance.playerHP -= 20;
                    ToastMessage.Instance.message = "������ �������Դ�. HP -20";
                }
                break;

            case 10: // EncounterPool[10]
                if (choiceIndex == 0)
                {
                    PlayerStatus.Instance.playerHP -= 5;
                    PlayerStatus.Instance.playerAD += 5;
                    PlayerStatus.Instance.playerAP -= 5;
                    ToastMessage.Instance.message = "HP -5, AD +5, AP -5";
                }
                else if (choiceIndex == 1)
                {
                    PlayerStatus.Instance.playerHP -= 5;
                    PlayerStatus.Instance.playerAP += 5;
                    PlayerStatus.Instance.playerAD -= 5;
                    ToastMessage.Instance.message = "HP -5, AD -5, AP +5";
                }
                else if (choiceIndex == 2)
                {
                    ToastMessage.Instance.message = "�����ƴ�.";
                }
                break;

            default:
                Debug.LogWarning($"EncounterIndex {encounterIndex}�� ������ {choiceIndex}�� ���� ó���� ���ǵ��� �ʾҽ��ϴ�.");
                break;
        }

        CloseEncounter();
        SceneManager.LoadScene("MapScene");
        ToastMessage.Instance.ShowMessage();
    }

    private void CloseEncounter()
    {
        if (currentUI != null)
            Destroy(currentUI);
    }
    private void ApplyRandomStatIncrease(int statIndex, int value)
{
    switch (statIndex)
    {
        case 0:
            PlayerStatus.Instance.playerHP += value;
            Debug.Log($"�������� HP +{value}");
            break;
        case 1:
            PlayerStatus.Instance.playerAD += value;
            Debug.Log($"�������� AD +{value}");
            break;
        case 2:
            PlayerStatus.Instance.playerAP += value;
            Debug.Log($"�������� AP +{value}");
            break;
        case 3:
            PlayerStatus.Instance.playerAR += value;
            Debug.Log($"�������� AR +{value}");
            break;
        case 4:
            PlayerStatus.Instance.playerMR += value;
            Debug.Log($"�������� MR +{value}");
            break;
    }
}

}
