using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using HexClass;
using TMPro;
using System.IO;
using System.Linq;
using Spine.Unity;
using Spine;
using UnityEditor;

public class GameManager_Move : MonoBehaviour
{
    public static GameManager_Move Instance;
    public string cellTag = "Cell";
    public Tilemap tilemap;
    //public TileBase tile;
    public GameObject player;

    private Vector3Int targetCell;
    private Vector3Int currentTargetCell; // ï¿½ï¿½ï¿½ï¿½ ï¿½Ã·ï¿½ï¿½Ì¾ï¿½ ï¿½Ìµï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ Å¸ï¿½ï¿½
    private bool is_P_Moving; // ï¿½Ã·ï¿½ï¿½Ì¾î°¡ Å¸ï¿½ï¿½ ï¿½Ìµï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Çºï¿½
    public TileBase highlightTile; // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ Å¸ï¿½ï¿½
    public Vector3Int playerCellPos;
    public Grid mygrid;
    public SkeletonAnimation p_animation;
    Animator playeranimator;

    private void Awake(){
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½Ç¾îµ? ï¿½Ä±ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Êµï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
        }
        else
        {
            Destroy(gameObject); // ï¿½ßºï¿½ï¿½ï¿½ ï¿½Î½ï¿½ï¿½Ï½ï¿½ï¿½ï¿½ ï¿½Ö´Ù¸ï¿½ ï¿½Ä±ï¿½
        }
    }
    


    private void Start()
    {
        is_P_Moving = false;
        playeranimator = player.GetComponent<Animator>();
    }
    private void Update()
    {
        GetRayCell();
        /*Vector3Int newPlayerCellPos = GetPlayerPos();
        if (newPlayerCellPos != playerCellPos)
        {
            playerCellPos = newPlayerCellPos;
            //HighlightNeighborCells(playerCellPos);
        }
        */
    }

    public void HighlightNeighborCells(Vector3Int playerCellPos)
    {
        Hex playerHex = new Hex(playerCellPos.x, playerCellPos.y);
        List<Hex> neighbors = playerHex.GetNeighbors();

        foreach (Hex neighbor in neighbors)
        {
            Vector3Int neighborPos = new Vector3Int(neighbor.q, neighbor.r, 0);
            tilemap.SetTile(neighborPos, highlightTile); // ï¿½Ì¿ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ Å¸ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
        }
    }

    private void GetRayCell() 
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

            Vector3Int? returnCell = CheckCell(hits);
            playerCellPos = GetPlayerPos();

            if (returnCell.HasValue)
            {
                HashSet<Hex> obstacles = new HashSet<Hex>();
                targetCell = returnCell.Value;
                List<Vector3Int> playerPath = new List<Vector3Int>();
                //tilemap.SetTile(targetCell, tile);
                //List<Vector3Int> playerPath = HexClass.HexPathfinding.FindPath(playerCellPos, targetCell, obstacles);
                if (is_P_Moving)
                {
                    StopAllCoroutines(); // ±âÁ¸ ÄÚ·çÆ¾ Áß´Ü
                    is_P_Moving = false; // ÀÌµ¿ »óÅÂ ÃÊ±âÈ­
                    return;
                }
                if (!is_P_Moving)
                {
                    playerPath = HexClass.HexPathfinding.FindPath(playerCellPos, targetCell, obstacles);
                    currentTargetCell = targetCell;
                    is_P_Moving = true;
                }
                //playerPath = HexClass.HexPathfinding.FindPath(currentTargetCell, targetCell, obstacles);

                //decreasecost
                if (UI_EnergyBar.Instance.GetPlayerEnergy() < playerPath.Count)
                {
                    playerPath = null;
                    StopAllCoroutines();
                    return;
                }
                else
                {
                    Debug.Log(playerPath);
                    UI_EnergyBar.Instance.DecreaseHealth(playerPath.Count - 1);
                    StartCoroutine(MovePath(playerPath));
                }
            }
        }
    }


    Vector3Int? CheckCell(RaycastHit2D[] hit) // ray hitï¿½ï¿½ï¿½ï¿½ cellï¿½ï¿½ ï¿½É·ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ô¼ï¿½. cellï¿½ï¿½ ï¿½ï¿½ ï¿½Ï³ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½.
    {
        foreach (var cell in hit)
        {
            if (cell.collider.CompareTag(cellTag)) // cellTagï¿½ï¿½ ï¿½ï¿½Ä¡ï¿½Ï¸ï¿½
            {
                Vector3 worldPosition = cell.point;
                Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);

                if (tilemap.HasTile(cellPosition))
                {
                    return cellPosition; // À¯È¿ÇÑ Å¸ÀÏÀÏ °æ¿ì ¹ÝÈ¯
                }

                return cellPosition;
            }
        }
        return null;
    }

    public Vector3Int GetPlayerPos()
    {
        Vector3Int playerCellPos = tilemap.WorldToCell(player.transform.position);
        return playerCellPos;
    }

    public IEnumerator MovePath(List<Vector3Int> path)
    {
        p_animation = player.GetComponent<SkeletonAnimation>();
        SkeletonDataAsset skeletonDataAsset = Resources.Load<SkeletonDataAsset>("PlayerAnimation/Move");
        p_animation.skeletonDataAsset = skeletonDataAsset;
        p_animation.Initialize(true);
        foreach (var cell in path)
        {
            playerCellPos = GetPlayerPos();
            Vector3 startWorldPos = tilemap.CellToWorld(playerCellPos); // ï¿½Ã·ï¿½ï¿½Ì¾î°¡ ï¿½Ö´ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ß¾ï¿½ ï¿½ï¿½Ç¥ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½. 
            Vector3 endWorldPos = tilemap.CellToWorld(cell); // cell. ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ß¾ï¿½ï¿½ï¿½Ç¥ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½.
            //Debug.DrawLine(startWorldPos, endWorldPos);
            yield return MoveCell(player,startWorldPos, endWorldPos);
        }
        is_P_Moving = false;
        skeletonDataAsset = Resources.Load<SkeletonDataAsset>("PlayerAnimation/Idle");
        p_animation.skeletonDataAsset = skeletonDataAsset;
        p_animation.Initialize(true);
    }


    public IEnumerator MoveCell(GameObject mover, Vector3 startWorldPos, Vector3 endWorldPos) // MoveCell ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ø¼ï¿½, ï¿½Ã·ï¿½ï¿½Ì¾ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½Ù¸ï¿½ ï¿½ï¿½Ã¼ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½Öµï¿½ï¿½ï¿½.
    {
        float elapsedTime = 0f;
        float duration = 0.4444f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            mover.transform.position = Vector3.Lerp(startWorldPos, endWorldPos, t);
            yield return null; 
        }

        // ï¿½ï¿½È®ï¿½ï¿½ ï¿½ï¿½Ç¥ ï¿½ï¿½Ä¡ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
        mover.transform.position = endWorldPos;
    }
    public void SetTilemap(Tilemap currentTilemap)
    {
        tilemap = currentTilemap;
    }
}
