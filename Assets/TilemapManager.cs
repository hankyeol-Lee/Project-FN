using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapManager : MonoBehaviour
{
    public Transform tilemapParent; // 타일맵을 로드할 부모 객체
    public GameObject[] tilemapPrefabs; // 타일맵 Prefab 배열

    private GameObject currentTilemap; // 현재 활성화된 타일맵
    // Start is called before the first frame update
    void Start()
    {
        LoadTilemap(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadTilemap(int mapIndex)
    {
        if (mapIndex < 0 || mapIndex >= tilemapPrefabs.Length)
        {
            Debug.LogError("Invalid map index!");
            return;
        }

        // 기존 타일맵 제거
        if (currentTilemap != null)
        {
            Destroy(currentTilemap);
        }

        // 새로운 타일맵 로드
        currentTilemap = Instantiate(tilemapPrefabs[mapIndex], tilemapParent);
    }
}