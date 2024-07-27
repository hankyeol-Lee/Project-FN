using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } //싱글톤 패턴 사용

    public GameObject player; // 플레이어 객체

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
