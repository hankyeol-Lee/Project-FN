using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        string scenename = SceneManager.GetActiveScene().name;
        if (scenename == "GamePlayScene")
        {
            if (Player.GetComponent<PlayerStatus>().playerHP <= 0)
            {
                Destroy(Player);

            }
            if (SpawnEnemy.instance.enemyInstances.Count == 0)
            {
                Debug.Log("Win");
                StartCoroutine(DelayedAction());

            }
        }
    }
        
    IEnumerator DelayedAction()
    {

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("VictoryScene");

    }
}

