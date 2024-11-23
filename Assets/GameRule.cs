using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    public GameObject Player;
    private bool isGameOver = false; // �� ��ȯ ���� �÷���

    void Update()
    {
        if (!isGameOver && Player.GetComponent<PlayerStatus>().playerHP <= 0)
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

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("VictoryScene");
    }
    IEnumerator DelayedAction2()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DefeatScene");
    }
}
