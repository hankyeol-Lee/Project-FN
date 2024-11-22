using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[InitializeOnLoad] // Unity 에디터가 로드될 때 자동 실행
public static class ItemDatabaseAutoRegister
{
    static ItemDatabaseAutoRegister()
    {
        // ItemDatabase 에셋 경로
        string databasePath = "Assets/ItemDatabase.asset";

        // ItemDatabase 에셋 로드
        ITEMDB itemDatabase = AssetDatabase.LoadAssetAtPath<ITEMDB>(databasePath);

        if (itemDatabase != null)
        {
            // Resources 폴더에서 모든 Item ScriptableObject 로드
            Item[] allItems = Resources.LoadAll<Item>("RelicData");

            // 아이템을 ItemDatabase의 리스트에 추가
            itemDatabase.items = new List<Item>(allItems);

            // 변경 사항 저장
            EditorUtility.SetDirty(itemDatabase);

            Debug.Log($"Registered {allItems.Length} items to ItemDatabase");
        }
        else
        {
            Debug.LogWarning($"ItemDatabase not found at path: {databasePath}. Please create it.");
        }
    }
}
