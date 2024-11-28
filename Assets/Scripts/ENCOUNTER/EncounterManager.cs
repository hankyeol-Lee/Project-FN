using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    public GameObject encounterUIPrefab; // UI 팝업 프리팹
    public Canvas canvas; // 팝업을 띄울 캔버스
    private GameObject currentUI; // 현재 활성화된 UI


    public void TriggerEncounter(EncounterData encounter)
    {
        // 팝업 생성
        currentUI = Instantiate(encounterUIPrefab, canvas.transform);

        // 팝업 설정
        TMP_Text encounterNameText = currentUI.transform.Find("EncounterNameText").GetComponent<TMP_Text>();
        TMP_Text encounterDescriptionText = currentUI.transform.Find("EncounterDescriptionText").GetComponent<TMP_Text>();
        Transform buttonGroup = currentUI.transform.Find("Buttons");

        // 데이터 설정
        encounterNameText.text = encounter.encounterName;
        encounterDescriptionText.text = encounter.encounterDescription;
        int Index = TriggerEvent.Instance.randomIndex;

        // 버튼 초기화
        foreach (Transform child in buttonGroup)
            Destroy(child.gameObject); // 기존 버튼 제거

        for (int i = 0; i < encounter.choices.Count; i++)
        {
            string choiceText = encounter.choices[i];
            int capturedIndex = i; // 캡처된 인덱스

            // 버튼 생성 및 설정
            GameObject buttonObject = new GameObject("Button", typeof(RectTransform), typeof(Button), typeof(Text));
            buttonObject.transform.SetParent(buttonGroup);

            RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1000, 50); // 버튼 크기

            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => HandleChoice(Index, capturedIndex)); // 캡처된 인덱스를 전달

            Text buttonText = buttonObject.GetComponent<Text>();
            buttonText.text = choiceText;
            buttonText.font = Resources.Load("HeirofLightRegular") as Font;
            buttonText.fontSize = 35;
            buttonText.alignment = TextAnchor.MiddleCenter;
            buttonText.color = Color.white;
        }

        // 닫기 버튼 설정
    }

    public void HandleChoice(int encounterIndex, int choiceIndex)
    {
        Debug.Log($"HandleChoice 호출됨: EncounterIndex={encounterIndex}, ChoiceIndex={choiceIndex}");
        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager.Instance가 null입니다. Singleton 초기화를 확인하세요.");
        return;
        }
        switch (encounterIndex)
        {
            case 0: // EncounterPool[0]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Old Helmet", "Old Sword", "Old Orb", "Old Armor", "Old Bead" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    Debug.Log($"{selectedRelic} Get");
                }
                break;

            case 3: // EncounterPool[3]
                if (choiceIndex == 0)
                {
                    float randomChance = Random.value; // 0.0 ~ 1.0 사이의 랜덤 값
                    if (randomChance <= 0.5f) // 50% 확률
                    {
                        string[] relics = { "Ordinary Helmet", "Ordinary Sword", "Ordinary Orb", "Ordinary Armor", "Ordinary Amulet", "Ordinary Boots" };
                        string selectedRelic = relics[Random.Range(0, relics.Length)];
                        InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                        Debug.Log($"{selectedRelic} Get");
                    }
                    else // 나머지 50% 확률
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        Debug.Log("HP -20");
                    }
                }
                else if (choiceIndex == 1)
                {
                    // 아무 동작 없음
                }
                break;

            case 4: // EncounterPool[4]
                if (choiceIndex == 0)
                {
                    Debug.Log("돌이었네요.");
                }
                else if (choiceIndex == 1)
                {
                    Debug.Log("지나쳤습니다. 그냥 돌이었네요.");
                }
                break;

            case 5: // EncounterPool[5]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Diamond", "Ruby", "Emerald", "Sapphire", "Garnet", "Amber" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    Debug.Log($"{selectedRelic} Get");
                }
                else if (choiceIndex == 1)
                {
                    Debug.Log("지나쳤습니다.");
                }
                break;

            case 6: // EncounterPool[6]
                if (choiceIndex == 0)
                {
                    string[] medals = { "Gold Medal", "Silver Medal", "Bronze Medal" };
                    string selectedMedal = medals[Random.Range(0, medals.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedMedal);
                    Debug.Log($"{selectedMedal} Get");
                }
                break;

            case 7: // EncounterPool[7]
                if (choiceIndex == 0)
                {
                    InventoryManager.Instance.AddRelicToInventory("Hero's Helmet");
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
                    Debug.Log($"{selectedRelic} Get");
                }
                break;

            case 9: // EncounterPool[9]
                if (choiceIndex == 0)
                {
                    if (PlayerStatus.Instance.playerAD >= 30)
                    {
                        Debug.Log("pass");
                    }
                    else
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        Debug.Log("fail: HP -20");
                    }
                }
                else if (choiceIndex == 1)
                {
                    if (PlayerStatus.Instance.playerAP >= 30)
                    {
                        Debug.Log("pass");
                    }
                    else
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        Debug.Log("fail: HP -20");
                    }
                }
                else if (choiceIndex == 2)
                {
                    PlayerStatus.Instance.playerHP -= 20;
                    Debug.Log("HP -20");
                }
                break;

            case 10: // EncounterPool[10]
                if (choiceIndex == 0)
                {
                    PlayerStatus.Instance.playerHP -= 5;
                    PlayerStatus.Instance.playerAD += 5;
                    PlayerStatus.Instance.playerAP -= 5;
                }
                else if (choiceIndex == 1)
                {
                    PlayerStatus.Instance.playerHP -= 5;
                    PlayerStatus.Instance.playerAP += 5;
                    PlayerStatus.Instance.playerAD -= 5;
                }
                else if (choiceIndex == 2)
                {
                    Debug.Log("pass");
                }
                break;

            default:
                Debug.LogWarning($"EncounterIndex {encounterIndex}와 선택지 {choiceIndex}에 대한 처리가 정의되지 않았습니다.");
                break;
        }

        CloseEncounter();
    }

    private void CloseEncounter()
    {
        if (currentUI != null)
            Destroy(currentUI);
    }
}
