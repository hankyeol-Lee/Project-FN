using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TilemapData", menuName = "TilemapData")]
public class TilemapData : ScriptableObject {
    public string mapName;
    public GameObject tilemapPrefab;
}
