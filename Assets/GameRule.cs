using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if (Player.GetComponent<PlayerStatus>().playerHP <= 0)
        {
            //�й�
        }
        if (EnemyInstances.enemyDict.Count == 0)
        {
            //�¸�
        }
    }
}

