using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; } //싱글톤 패턴 사용, 전역으로 접근할 오브젝트들 추가

    public GameObject player; // 플레이어 객체

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
}
