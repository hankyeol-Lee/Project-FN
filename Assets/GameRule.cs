using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    public bool isWin = false;
    public GameObject Player;
    private bool isGameOver = false; // �� ��ȯ ���� �÷���

    void Update()
    {
        string thisscene = SceneManager.GetActiveScene().name;
        if (!string.IsNullOrEmpty(thisscene))
        {
            if (!isGameOver && PlayerStatus.Instance.playerHP <= 0)
            {
                isGameOver = true;
                Destroy(Player);
                StartCoroutine(DelayedAction2());
            }

            if (!isGameOver && SpawnEnemy.instance.enemyInstances.Count == 0)
            {
                Debug.Log("Win");
                isGameOver = true; // �÷��� ����
                StartCoroutine(DelayedAction());
            }
        }
        
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(3f);
        isWin = true;   
        SceneManager.LoadScene("VictoryScene");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MapScene");
    }
    IEnumerator DelayedAction2()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DefeatScene");

        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("MapScene");
    }
}
