using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseSingleton : MonoBehaviour
{
    public static ItemDatabaseSingleton Instance; // �̱��� �ν��Ͻ�
    public ITEMDB itemDatabase; // ScriptableObject�� ���� ItemDatabase�� ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ������ �̸����� �˻�
    public Item GetItemByName(string itemName)
    {
        return itemDatabase.GetItemByName(itemName);
    }
}
