using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    // Start is called before the first frame update
    public List<Item> items; // ��� �������� �����ϴ� ����Ʈ

    // Ư�� �̸����� ������ �˻�
    public Item GetItemByName(string itemName)
    {
        return items.Find(item => item.ItemName == itemName);
    }
}
