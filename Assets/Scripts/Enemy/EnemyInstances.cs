using Enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyList;

public class EnemyInstances : MonoBehaviour
{
    public static Dictionary<string, Enemy> enemyDict = new Dictionary<string, Enemy>();
    private void Awake()
    {
        InitializeEnemy();
    }
    private void InitializeEnemy()
    {
        EnemyData[] enemyDataList = Resources.LoadAll<EnemyData>("EnemyData");

        foreach (var data in enemyDataList)
        {
            switch(data.Name)
            {
                case "Slime":
                    enemyDict[data.Name] = new Slime(data);
                    break;
                case "GiantRat":
                    enemyDict[data.Name] = new GiantRat(data);
                    break;
                case "WeedSpirit":
                    enemyDict[data.Name] = new WeedSpirit(data);
                    break;
                case "Goblin":
                    enemyDict[data.Name] = new Goblin(data);
                    break;
                default:
                    Debug.LogWarning($"없는게 들어옴 {data.Name}");
                    break;
            }
        }
    }
}
