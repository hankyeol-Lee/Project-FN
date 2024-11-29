using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Transform tilemapParent; // ????��맵을 로드?�� �?�? 객체
    public GameObject[] tilemapPrefabs; // ????���? Prefab 배열

    private GameObject currentTilemap; // ?��?�� ?��?��?��?�� ????���?
    // Start is called before the first frame update
    void Start()
    {
        int randomvalue = Random.Range(0, 10);
        LoadTilemap(randomvalue);
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

        // 기존 ????���? ?���?
        if (currentTilemap != null)
        {
            Destroy(currentTilemap);
        }

        // ?��로운 ????���? 로드
        GameObject map = Instantiate(tilemapPrefabs[mapIndex], tilemapParent);
        currentTilemap = map;
        currentTilemap.transform.position = new Vector3(0,0,0);
        GameManager.Instance.SetTilemap(map.GetComponent<Tilemap>());
        GameManager_Move.Instance.SetTilemap(map.GetComponent<Tilemap>()); 
        SkillSystem.Instance.SetTilemap(map.GetComponent<Tilemap>());
    }
}
