using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    public GameObject encounterUIPrefab; // UI 팝업 프리팹
    public Canvas canvas; // 팝업을 띄울 캔버스
    private GameObject currentUI; // 현재 활성화된 UI
    private static EncounterManager Instance;


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
        
        switch (encounterIndex)
        {
            case 0: // EncounterPool[0]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Old Helmet", "Old Sword", "Old Orb", "Old Armor", "Old Bead" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    ToastMessage.Instance.message = $"{selectedRelic} 획득";
                }
                break;
                    case 1: // EncounterPool[1]
            switch (choiceIndex)
            {
                case 0: // 1번 선택지
                    PlayerStatus.Instance.playerHP -= 50;
                    PlayerStatus.Instance.playerAR += 10;
                    PlayerStatus.Instance.playerMR += 10;
                    Debug.Log("1번 선택지: HP -50, AR +10, MR +10");
                    break;
                case 1: // 2번 선택지
                    int randomStat1 = Random.Range(0, 5);
                    ApplyRandomStatIncrease(randomStat1, 15);
                    Debug.Log($"2번 선택지: 랜덤 스탯 +15");
                    break;
                case 2: // 3번 선택지
                    PlayerStatus.Instance.playerHP -= 50;
                    PlayerStatus.Instance.playerAD += 15;
                    Debug.Log("3번 선택지: HP -50, AD +15");
                    break;
                case 3: // 4번 선택지
                    PlayerStatus.Instance.playerAD += 15;
                    PlayerStatus.Instance.playerAP += 15;
                    PlayerStatus.Instance.playerAR -= 10;
                    PlayerStatus.Instance.playerMR -= 10;
                    Debug.Log("4번 선택지: AD +15, AP +15, AR -10, MR -10");
                    break;
                case 4: // 5번 선택지
                    PlayerStatus.Instance.playerHP -= 50;
                    PlayerStatus.Instance.playerAP += 15;
                    Debug.Log("5번 선택지: HP -50, AP +15");
                    break;
                case 5: // 6번 선택지
                    PlayerStatus.Instance.playerHP += 200;
                    PlayerStatus.Instance.playerAR -= 10;
                    PlayerStatus.Instance.playerMR -= 10;
                    Debug.Log("6번 선택지: HP +200, AR -10, MR -10");
                    break;
                case 6: // 7번 선택지
                    PlayerStatus.Instance.playerHP += 200;
                    PlayerStatus.Instance.costResilience = 100;
                    Debug.Log("7번 선택지: HP +200, costResilience = 100");
                    break;
            }
            break;

        case 2: // EncounterPool[2]
            switch (choiceIndex)
            {
                case 0: // 1번 선택지
                    PlayerStatus.Instance.playerHP += 100;
                    Debug.Log("1번 선택지: HP +100");
                    break;
                case 1: // 2번 선택지
                    int randomStat2 = Random.Range(0, 5);
                    ApplyRandomStatIncrease(randomStat2, 15);
                    Debug.Log($"2번 선택지: 랜덤 스탯 +15");
                    break;
                case 2: // 3번 선택지
                    PlayerStatus.Instance.playerHP += 150;
                    PlayerStatus.Instance.playerAD -= 5;
                    Debug.Log("3번 선택지: HP +150, AD -5");
                    break;
                case 3: // 4번 선택지
                    PlayerStatus.Instance.playerAD -= 5;
                    PlayerStatus.Instance.playerAP -= 5;
                    PlayerStatus.Instance.playerAR += 10;
                    PlayerStatus.Instance.playerMR += 10;
                    Debug.Log("4번 선택지: AD -5, AP -5, AR +10, MR +10");
                    break;
                case 4:
                    PlayerStatus.Instance.playerHP += 150;
                    PlayerStatus.Instance.playerAP -= 5;
                    Debug.Log("5번 선택지: HP +150, AP -5");
                    break;
                case 5: // 5번 선택지
                    PlayerStatus.Instance.playerAR += 5;
                    PlayerStatus.Instance.playerMR += 5;
                    Debug.Log("6번 선택지: AR +5, MR +5");
                    break;
                case 6: // 6번 선택지
                    PlayerStatus.Instance.costResilience = 300;
                    Debug.Log("7번 선택지: costResilience = 200");
                    break;
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
                        ToastMessage.Instance.message = $"{selectedRelic} 획득";
                    }
                    else // 나머지 50% 확률
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        ToastMessage.Instance.message = "HP -20";
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
                    ToastMessage.Instance.message = "돌이었네요.";
                }
                else if (choiceIndex == 1)
                {
                    ToastMessage.Instance.message = "지나쳤습니다. 그냥 돌이었네요.";
                }
                break;

            case 5: // EncounterPool[5]
                if (choiceIndex == 0)
                {
                    string[] relics = { "Diamond", "Ruby", "Emerald", "Sapphire", "Garnet", "Amber" };
                    string selectedRelic = relics[Random.Range(0, relics.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedRelic);
                    ToastMessage.Instance.message = $"{selectedRelic} 획득";
                }
                else if (choiceIndex == 1)
                {
                    ToastMessage.Instance.message = "지나쳤습니다.";
                }
                break;

            case 6: // EncounterPool[6]
                if (choiceIndex == 0)
                {
                    string[] medals = { "Gold Medal", "Silver Medal", "Bronze Medal" };
                    string selectedMedal = medals[Random.Range(0, medals.Length)];
                    InventoryManager.Instance.AddRelicToInventory(selectedMedal);
                    ToastMessage.Instance.message = $"{selectedMedal} 획득";
                }
                break;

            case 7: // EncounterPool[7]
                if (choiceIndex == 0)
                {
                    InventoryManager.Instance.AddRelicToInventory("Hero's Helmet");
                    ToastMessage.Instance.message = "Hero's Helmet 획득";
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
                    ToastMessage.Instance.message = $"{selectedRelic} 획득";
                }
                break;

            case 9: // EncounterPool[9]
                if (choiceIndex == 0)
                {
                    if (PlayerStatus.Instance.playerAD >= 30)
                    {
                        ToastMessage.Instance.message = "무사히 탈출했다.";
                    }
                    else
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        ToastMessage.Instance.message = "역부족이었다. 억지로 빠져나왔다. HP -20";
                    }
                }
                else if (choiceIndex == 1)
                {
                    if (PlayerStatus.Instance.playerAP >= 30)
                    {
                        ToastMessage.Instance.message = "무사히 탈출했다.";
                    }
                    else
                    {
                        PlayerStatus.Instance.playerHP -= 20;
                        ToastMessage.Instance.message = "역부족이었다. 억지로 빠져나왔다. HP -20";
                    }
                }
                else if (choiceIndex == 2)
                {
                    PlayerStatus.Instance.playerHP -= 20;
                    ToastMessage.Instance.message = "억지로 빠져나왔다. HP -20";
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
                    ToastMessage.Instance.message = "지나쳤다.";
                }
                break;

            default:
                Debug.LogWarning($"EncounterIndex {encounterIndex}와 선택지 {choiceIndex}에 대한 처리가 정의되지 않았습니다.");
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
            Debug.Log($"랜덤으로 HP +{value}");
            break;
        case 1:
            PlayerStatus.Instance.playerAD += value;
            Debug.Log($"랜덤으로 AD +{value}");
            break;
        case 2:
            PlayerStatus.Instance.playerAP += value;
            Debug.Log($"랜덤으로 AP +{value}");
            break;
        case 3:
            PlayerStatus.Instance.playerAR += value;
            Debug.Log($"랜덤으로 AR +{value}");
            break;
        case 4:
            PlayerStatus.Instance.playerMR += value;
            Debug.Log($"랜덤으로 MR +{value}");
            break;
    }
}

}
