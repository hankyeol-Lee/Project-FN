using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[InitializeOnLoad] // Unity �����Ͱ� �ε�� �� �ڵ� ����
public static class ItemDatabaseAutoRegister
{
    static ItemDatabaseAutoRegister()
    {
        // ItemDatabase ���� ���
        string databasePath = "Assets/ItemDatabase.asset";

        // ItemDatabase ���� �ε�
        ItemDatabase itemDatabase = AssetDatabase.LoadAssetAtPath<ItemDatabase>(databasePath);

        if (itemDatabase != null)
        {
            // Resources �������� ��� Item ScriptableObject �ε�
            Item[] allItems = Resources.LoadAll<Item>("RelicData");

            // �������� ItemDatabase�� ����Ʈ�� �߰�
            itemDatabase.items = new List<Item>(allItems);

            // ���� ���� ����
            EditorUtility.SetDirty(itemDatabase);

            Debug.Log($"Registered {allItems.Length} items to ItemDatabase");
        }
        else
        {
            Debug.LogWarning($"ItemDatabase not found at path: {databasePath}. Please create it.");
        }
    }
}
