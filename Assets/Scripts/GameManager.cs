using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; } //싱글톤 패턴 사용, 전역으로 접근할 오브젝트들 추가
    public GameManager_Move gameManagerMove; // GameManager_Move 참조

    public GameObject player; // 플레이어 객체
    public GameObject floatingtextmanager; // 데미지 텍스트 띄우는 객체도 싱글톤으로 해야 함.

    public Tilemap tilemap; // 

    public skillHexRadius skillHexRadius;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 변경되어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스가 있다면 파괴
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
    
}
