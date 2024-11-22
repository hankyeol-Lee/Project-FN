using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    // Start is called before the first frame update
    public List<Item> items; // 모든 아이템을 저장하는 리스트

    // 특정 이름으로 아이템 검색
    public Item GetItemByName(string itemName)
    {
        return items.Find(item => item.ItemName == itemName);
    }
}
