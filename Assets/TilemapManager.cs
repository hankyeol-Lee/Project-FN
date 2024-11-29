using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Transform tilemapParent; // ????¼ë§µì„ ë¡œë“œ?•  ë¶?ëª? ê°ì²´
    public GameObject[] tilemapPrefabs; // ????¼ë§? Prefab ë°°ì—´

    private GameObject currentTilemap; // ?˜„?¬ ?™œ?„±?™”?œ ????¼ë§?
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

        // ê¸°ì¡´ ????¼ë§? ? œê±?
        if (currentTilemap != null)
        {
            Destroy(currentTilemap);
        }

        // ?ƒˆë¡œìš´ ????¼ë§? ë¡œë“œ
        GameObject map = Instantiate(tilemapPrefabs[mapIndex], tilemapParent);
        currentTilemap = map;
        currentTilemap.transform.position = new Vector3(0,0,0);
        GameManager.Instance.SetTilemap(map.GetComponent<Tilemap>());
        GameManager_Move.Instance.SetTilemap(map.GetComponent<Tilemap>()); 
        SkillSystem.Instance.SetTilemap(map.GetComponent<Tilemap>());
    }
}
