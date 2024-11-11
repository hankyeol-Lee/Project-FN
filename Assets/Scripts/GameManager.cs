using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; } //�̱��� ���� ���, �������� ������ ������Ʈ�� �߰�

    public GameObject player; // �÷��̾� ��ü

    public Tilemap tilemap; // 

    public skillHexRadius skillHexRadius;

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
}
