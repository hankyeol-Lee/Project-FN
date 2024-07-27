using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } //�̱��� ���� ���

    public GameObject player; // �÷��̾� ��ü

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
