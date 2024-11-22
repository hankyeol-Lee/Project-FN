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
            //ÆÐ¹è
        }
        if (EnemyInstances.enemyDict.Count == 0)
        {
            //½Â¸®
        }
    }
}

