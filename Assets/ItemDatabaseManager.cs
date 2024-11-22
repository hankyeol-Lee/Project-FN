using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseSingleton : MonoBehaviour
{
    public static ItemDatabaseSingleton Instance; // 싱글톤 인스턴스
    public ITEMDB itemDatabase; // ScriptableObject로 만든 ItemDatabase를 참조

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 아이템 이름으로 검색
    public Item GetItemByName(string itemName)
    {
        return itemDatabase.GetItemByName(itemName);
    }
}
