using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; } //�̱��� ���� ���, �������� ������ ������Ʈ�� �߰�
    public GameManager_Move gameManagerMove; // GameManager_Move ����

    public GameObject player; // �÷��̾� ��ü
    public GameObject floatingtextmanager; // ������ �ؽ�Ʈ ���� ��ü�� �̱������� �ؾ� ��.
    public GameObject EnemySpawner;

    public Tilemap tilemap; // 
    public Grid mygrid;
    public skillHexRadius skillHexRadius;

    void Start()
    {      
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� ����Ǿ �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ��� �ִٸ� �ı�
        }
        
        SceneManager.LoadScene("BattleUIScene",LoadSceneMode.Additive);
       
    }
    public Vector3 PlayerCellToWorld(Vector3Int playerCellPos)
    {
        return tilemap.CellToWorld(playerCellPos);
    }

    public Vector3Int PlayerWorldToCell(Vector3 playerWorldPos)
    {
        return tilemap.WorldToCell(playerWorldPos);
    }
    public bool IsTargetOnCell(Vector3Int cellPos)
    {
       gameManagerMove = GetComponent<GameManager_Move>();
       if (GameManager.Instance.gameManagerMove.GetPlayerPos() == cellPos) { return true; }
       return false;
    }
    public float DamageSystem(float skillcoef,ActiveSkill.skillType skilltype,float AttackPoint)
    {
        return skillcoef * AttackPoint;
    }
    public void SetTilemap(Tilemap currentTilemap)
    {
        tilemap = currentTilemap;
    }
    
}
